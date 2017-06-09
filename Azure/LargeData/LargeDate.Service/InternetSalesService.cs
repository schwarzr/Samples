using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LargeData.Database;
using LargeData.Model;
using LargeData.Model.Custom;
using LargeDate.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace LargeDate.Service
{
    public class InternetSalesService : IInternetSalesService, INotifyPropertyChanged
    {
        private readonly IServiceProvider _serviceProvider;

        private TimeSpan valLastRequestDuration;

        public InternetSalesService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TimeSpan LastRequestDuration
        {
            get { return valLastRequestDuration; }
            set
            {
                if (valLastRequestDuration != value)
                {
                    valLastRequestDuration = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastRequestDuration)));
                }
            }
        }

        public int LastRequestSize => 0;

        public async Task<IEnumerable<InternetSaleInfo>> GetInternetSaleInfosAsync(DateTime? from, DateTime? until)
        {
            return await Process(async context =>
            {
                var query = await InternetSalesDataAccess.GetInternetSaleInfosQueryAsync(context, from, until);
                return await query.ToListAsync();
            });
        }

        public async Task<Stream> GetInternetSaleInfoStreamAsync(DateTime? from, DateTime? until)
        {
            var context = _serviceProvider.GetRequiredService<AdventureWorksContext>();

            var query = await InternetSalesDataAccess.GetInternetSaleInfosQueryAsync(context, from, until);

            return new GZipStream(new DataStream<InternetSaleInfo>(query), CompressionLevel.Fastest);
        }

        public async Task<IEnumerable<InternetSale>> GetInternetSalesAsync(DateTime? from, DateTime? until)
        {
            return await Process(async context =>
            {
                var query = await InternetSalesDataAccess.GetInternetSalesQueryAsync(context, from, until);
                var result = await query.ToListAsync();
                return result;
            });
        }

        protected virtual IServiceScope CreateScope()
        {
            return _serviceProvider.CreateScope();
        }

        private async Task<TResult> Process<TResult>(Func<AdventureWorksContext, Task<TResult>> work)
        {
            using (var scope = CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AdventureWorksContext>();

                var sw = new Stopwatch();
                sw.Start();

                var result = await work(context);

                sw.Stop();
                LastRequestDuration = sw.Elapsed;

                return result;
            }
        }
    }
}