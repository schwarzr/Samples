using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using ProtoBuf.Meta;

namespace LargeDate.UI
{
    public class DataStreamReader<TItem>
    {
        private Type _runtimeType;

        private TypeModel _typeModel;

        public DataStreamReader(Stream inputStream, Type runtimeType = null, TypeModel typeModel = null)
        {
            InputStream = inputStream;

            this._runtimeType = runtimeType ?? typeof(TItem);

            if (runtimeType != null && !typeof(TItem).IsAssignableFrom(runtimeType))
            {
                throw new ArgumentOutOfRangeException(nameof(runtimeType), $"The type must be a subtype of {typeof(TItem)}.");
            }

            this._typeModel = typeModel ?? RuntimeTypeModel.Default;
        }

        public Stream InputStream { get; }

        public async Task ReadDataAsync(IProgress<TItem> progress)
        {
            await ReadDataAsync(progress.Report);
        }

        private TItem GetItemFromBuffer(byte[] itemBuffer)
        {
            using (var ms = new MemoryStream(itemBuffer))
            {
                return (TItem)_typeModel.Deserialize(ms, null, _runtimeType);
            }
        }

        private async Task ReadDataAsync(Action<TItem> itemAction)
        {
            var buffer = new byte[4];
            var count = await ReadStreamAsync(InputStream, buffer, 0, 4).ConfigureAwait(false);

            while (count > 0)
            {
                var length = BitConverter.ToInt32(buffer, 0);
                var itemBuffer = new byte[length];

                if (length > 0)
                {
                    var ct = await ReadStreamAsync(InputStream, itemBuffer, 0, length).ConfigureAwait(false);
                    if (ct != length)
                    {
                        throw new InvalidDataException("the input stream is in a wrong format");
                    }
                }

                var item = GetItemFromBuffer(itemBuffer);
                itemAction(item);

                count = await ReadStreamAsync(InputStream, buffer, 0, 4).ConfigureAwait(false);
                if (count > 0 && count != 4)
                {
                    throw new InvalidDataException("the input stream is in a wrong format");
                }
            }
        }

        private async Task<int> ReadStreamAsync(Stream baseStream, byte[] buffer, int offset, int count)
        {
            var ct = await baseStream.ReadAsync(buffer, offset, count).ConfigureAwait(false);
            var read = ct;
            while (read < count)
            {
                ct = await baseStream.ReadAsync(buffer, offset + read, count - read).ConfigureAwait(false);
                if (ct == 0)
                {
                    break;
                }

                read += ct;
            }

            return read;
        }
    }
}