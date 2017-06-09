using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf.Meta;

namespace LargeDate.Service
{
    public class DataStream<TItem> : Stream
    {
        private readonly IEnumerator<TItem> _enumerator;
        private bool _isDone;
        private byte[] _itemBuffer;
        private int _itemBufferPosition;
        private Type _runtimeType;
        private ProtoBuf.Meta.TypeModel _typeModel;

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DataStream(IEnumerable<TItem> items, Type runtimeType = null, TypeModel typeModel = null)
        {
            this._enumerator = items.GetEnumerator();
            this._runtimeType = runtimeType;
            if (runtimeType != null && !typeof(TItem).IsAssignableFrom(runtimeType))
            {
                throw new ArgumentOutOfRangeException(nameof(runtimeType), $"The type must be a subtype of {typeof(TItem)}.");
            }

            this._typeModel = typeModel ?? ProtoBuf.Meta.RuntimeTypeModel.Default;
        }

        /// <summary>
        /// When overridden in a derived class, gets a value indicating whether the current stream supports reading.
        /// </summary>
        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override long Length
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var result = 0;
            int countToUse = 0;
            var toCopy = count;
            var currentOffset = offset;

            do
            {
                if (this._itemBuffer == null)
                {
                    if (_isDone)
                    {
                        return result;
                    }

                    bool hasNext = _enumerator.MoveNext();

                    if (!hasNext)
                    {
                        _isDone = true;
                        _enumerator.Dispose();

                        return result;
                    }

                    this._itemBuffer = GetItemBuffer(_enumerator.Current);
                    this._itemBufferPosition = 0;
                }

                countToUse = Math.Min(toCopy, this._itemBuffer.Length - this._itemBufferPosition);

                Buffer.BlockCopy(this._itemBuffer, this._itemBufferPosition, buffer, currentOffset, countToUse);
                this._itemBufferPosition += countToUse;
                result += countToUse;
                toCopy -= countToUse;
                currentOffset += countToUse;

                if (this._itemBufferPosition >= this._itemBuffer.Length)
                {
                    this._itemBuffer = null;
                    this._itemBufferPosition = 0;
                }
            }
            while (result < count);

            return result;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !_isDone)
            {
                _isDone = true;
                this._enumerator.Dispose();
            }

            base.Dispose(disposing);
        }

        private byte[] GetItemBuffer(TItem current)
        {
            using (var ms = new MemoryStream())
            {
                _typeModel.Serialize(ms, current);
                ms.Seek(0, SeekOrigin.Begin);
                var result = new byte[ms.Length + 4];
                var read = ms.Read(result, 4, result.Length - 4);
                if (read != result.Length - 4)
                {
                    throw new NotSupportedException("this should not happen");
                }

                var length = BitConverter.GetBytes(result.Length - 4);

                Buffer.BlockCopy(length, 0, result, 0, 4);

                return result;
            }
        }
    }
}