using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using LargeData.Model;
using LargeData.Model.Custom;
using LargeDate.Contract;
using Newtonsoft.Json;
using ProtoBuf.Meta;

namespace LargData.Remote
{
    public class RemoteInternetSalesService : IInternetSalesService, INotifyPropertyChanged
    {
        private static Lazy<RuntimeTypeModel> model = new Lazy<RuntimeTypeModel>(CreateTypeModel);

        private readonly string _baseUrl;

        private readonly bool _compression;
        private readonly SerializationStrategy _strategy;

        private TimeSpan valLastRequestDuration;

        private int valLastRequestSize;

        public RemoteInternetSalesService(string baseUrl, SerializationStrategy strategy = SerializationStrategy.Xml, bool compression = false)
        {
            _compression = compression;
            _baseUrl = baseUrl;
            _strategy = strategy;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static RuntimeTypeModel Model
        {
            get { return model.Value; }
        }

        public TimeSpan LastRequestDuration
        {
            get { return valLastRequestDuration; }
            private set
            {
                if (valLastRequestDuration != value)
                {
                    valLastRequestDuration = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastRequestDuration)));
                }
            }
        }

        public int LastRequestSize
        {
            get { return valLastRequestSize; }
            private set
            {
                if (valLastRequestSize != value)
                {
                    valLastRequestSize = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastRequestSize)));
                }
            }
        }

        public async Task<IEnumerable<InternetSaleInfo>> GetInternetSaleInfosAsync(DateTime? from, DateTime? until)
        {
            var url = $"{_baseUrl}/api/InternetSales/info?from={from}&until={until}";

            return await ProcessRequest<IEnumerable<InternetSaleInfo>>(url);
        }

        public async Task<Stream> GetInternetSaleInfoStreamAsync(DateTime? from, DateTime? until)
        {
            var sw = new Stopwatch();
            sw.Start();
            var client = new WebClient();
            var url = $"{_baseUrl}/api/InternetSales/info/stream?from={from}&until={until}";

            var result = await client.OpenReadTaskAsync(url);

            sw.Stop();
            this.LastRequestDuration = sw.Elapsed;

            return result;
        }

        public async Task<IEnumerable<InternetSale>> GetInternetSalesAsync(DateTime? from, DateTime? until)
        {
            var url = $"{_baseUrl}/api/InternetSales?from={from}&until={until}";

            return await ProcessRequest<IEnumerable<InternetSale>>(url);
        }

        protected virtual void AddHeaders(WebClient client)
        {
            switch (this._strategy)
            {
                case SerializationStrategy.Xml:
                    client.Headers.Add(HttpRequestHeader.Accept, "application/xml");
                    break;

                case SerializationStrategy.Json:
                    client.Headers.Add(HttpRequestHeader.Accept, "application/Json");
                    break;

                case SerializationStrategy.ProtoBuf:
                    client.Headers.Add(HttpRequestHeader.Accept, "application/x-protobuf");
                    break;
            }
        }

        protected virtual TValue Deserialize<TValue>(MemoryStream ms)
        {
            switch (this._strategy)
            {
                case SerializationStrategy.Xml:
                    var ser = new DataContractSerializer(typeof(TValue));
                    return (TValue)ser.ReadObject(ms);

                case SerializationStrategy.Json:
                    var jsonSer = JsonSerializer.Create();
                    using (var sr = new StreamReader(ms))
                    {
                        using (var jtr = new JsonTextReader(sr))
                        {
                            var result = jsonSer.Deserialize<TValue>(jtr);
                            return result;
                        }
                    }
                case SerializationStrategy.ProtoBuf:
                    return (TValue)Model.Deserialize(ms, null, typeof(TValue));
            }

            return default(TValue);
        }

        private static RuntimeTypeModel CreateTypeModel()
        {
            var typeModel = TypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        }

        private async Task<TValue> ProcessRequest<TValue>(string url)
        {
            var sw = new Stopwatch();
            sw.Start();
            using (var ms = new MemoryStream())
            {
                using (var client = new MyWebClient(_compression))
                {
                    AddHeaders(client);

                    using (var requestStream = await client.OpenReadTaskAsync(url))
                    {
                        await requestStream.CopyToAsync(ms);
                    }
                }
                LastRequestSize = (int)ms.Length;
                ms.Seek(0, SeekOrigin.Begin);
                var result = Deserialize<TValue>(ms);
                sw.Stop();
                this.LastRequestDuration = sw.Elapsed;

                return result;
            }
        }

        private class MyWebClient : WebClient
        {
            private bool _compression;

            public MyWebClient(bool compression)
            {
                _compression = compression;
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
                if (_compression)
                {
                    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                }
                return request;
            }
        }
    }
}