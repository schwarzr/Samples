using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CsvHelper;
using LargeData.Model;
using LargeData.Model.Custom;
using LargeData.UI.Common;
using LargeDate.Contract;
using LargeDate.UI;

namespace LargeData.UI.ViewModel
{
    public class LargeDataViewModel : NotificationObject
    {
        private readonly ConcurrentDictionary<object, string> _busyState = new ConcurrentDictionary<object, string>();
        private readonly object _itemsLocker = new object();
        private string _busyMessage;
        private DateTime? _from;
        private bool _isBusy;
        private ObservableCollection<InternetSale> _items;
        private DateTime? _until;

        public LargeDataViewModel(IInternetSalesService service)
        {
            Service = service;
            ExportCommand = new DelegateCommand(ExportExcel);
            this._from = new DateTime(2014, 1, 1);
        }

        public string BusyMessage
        {
            get { return _busyMessage; }
            set
            {
                if (_busyMessage != value)
                {
                    _busyMessage = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DelegateCommand ExportCommand { get; private set; }

        public DateTime? From
        {
            get { return _from; }
            set
            {
                if (_from != value)
                {
                    _from = value;
                    RaisePropertyChanged();
                    LoadDataAsync();
                }
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ObservableCollection<InternetSale> Items
        {
            get { return _items; }
            private set
            {
                if (_items != value)
                {
                    if (_items != null)
                    {
                        BindingOperations.DisableCollectionSynchronization(_items);
                    }

                    _items = value;

                    if (_items != null)
                    {
                        BindingOperations.EnableCollectionSynchronization(_items, _itemsLocker);
                    }

                    RaisePropertyChanged();
                }
            }
        }

        public IInternetSalesService Service { get; }

        public DateTime? Until
        {
            get { return _until; }
            set
            {
                if (_until != value)
                {
                    _until = value;
                    RaisePropertyChanged();
                    LoadDataAsync();
                }
            }
        }

        public async Task InitializeAsync()
        {
            await LoadDataAsync();
        }

        protected async Task LoadDataAsync()
        {
            using (StartJob("loading..."))
            {
                // Step 1 - eager loaded entity objects
                var items = await Service.GetInternetSalesAsync(this.From, this.Until);
                this.Items = new ObservableCollection<InternetSale>(items);

                // Step 2 - mapped object from service
                //var items = await Service.GetInternetSaleInfosAsync(this.From, this.Until);
                //this.Items = new ObservableCollection<InternetSaleInfo>(items);

                // Step 3 - Streamed requests
                //this.Items = new ObservableCollection<InternetSaleInfo>();
                //var stream = await Service.GetInternetSaleInfoStreamAsync(this.From, this.Until);
                //var dr = new DataStreamReader<InternetSaleInfo>(stream);
                //var processor = new ChunkLoad<InternetSaleInfo>(this.Items, 1000);
                //await dr.ReadDataAsync(processor);
                //processor.Complete();
            }
        }

        private void ExportExcel(object obj)
        {
            var file = Path.GetTempFileName() + ".csv";

            // Step 1
            var mapped = this.Items.Select(p => new InternetSaleInfo
            {
                Order = p.SalesOrderNumber,
                Pos = p.SalesOrderLineNumber,
                Customer = p.Customer.FirstName + " " + p.Customer.LastName,
                CustomerLocation = p.Customer.Geography.City + " (" + p.Customer.Geography.EnglishCountryRegionName + ")",
                Quantity = p.OrderQuantity,
                Price = p.UnitPrice,
                Currency = p.Currency.CurrencyName,
                Total = p.SalesAmount,
                Date = p.OrderDate,
                Promotion = p.Promotion.EnglishPromotionName
            });

            // Step 2 + 3
            //var mapped = this.Items;

            using (var fs = File.OpenWrite(file))
            {
                using (var sw = new StreamWriter(fs))
                {
                    using (var writer = new CsvWriter(sw, new CsvHelper.Configuration.CsvConfiguration { Delimiter = ";" }))
                    {
                        writer.WriteRecords(mapped);
                    }
                }
            }
            Process.Start(file);
        }

        private IDisposable StartJob(string message)
        {
            return new BusyJob(message, this);
        }

        private class BusyJob : IDisposable
        {
            private LargeDataViewModel largeDataViewModel;
            private string message;

            public BusyJob(string message, LargeDataViewModel largeDataViewModel)
            {
                this.state = new object();
                this.message = message;
                this.largeDataViewModel = largeDataViewModel;
                this.largeDataViewModel._busyState.TryAdd(state, message);
                InvalidateBusyContent();
            }

            #region IDisposable Support

            private readonly object state;
            private bool disposedValue = false; // To detect redundant calls

            public void Dispose()
            {
                Dispose(true);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        string message;

                        largeDataViewModel._busyState.TryRemove(this.state, out message);
                        InvalidateBusyContent();
                    }

                    disposedValue = true;
                }
            }

            private void InvalidateBusyContent()
            {
                largeDataViewModel.IsBusy = largeDataViewModel._busyState.Any();
                largeDataViewModel.BusyMessage = largeDataViewModel._busyState.Values.FirstOrDefault();
            }

            #endregion IDisposable Support
        }
    }
}