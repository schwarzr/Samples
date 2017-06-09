using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LargData.Remote;
using LargeData.Database;
using LargeData.UI.ViewModel;
using LargeDate.Contract;
using LargeDate.Service;
using Microsoft.Extensions.DependencyInjection;

namespace LargeData.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected virtual void OnConfigure(IServiceCollection service)
        {
            var serviceUrl = "http://largedataweb.azurewebsites.net";

            service.AddScoped<AdventureWorksContext>();

            // Direct access
            // Local Database
            service.AddScoped<AdventureWorksContext>(p => new AdventureWorksContext("name=AdventureWorksContext"));
            // Azure Database
            //service.AddScoped<AdventureWorksContext>(o => new AdventureWorksContext("name=AzureAdventureWorksContext"));
            service.AddScoped<IInternetSalesService, InternetSalesService>();

            // REST Service access
            // XML serializer
            //service.AddScoped<IInternetSalesService>(p => new RemoteInternetSalesService(serviceUrl, SerializationStrategy.Xml, false));

            // JSON serializer
            //service.AddScoped<IInternetSalesService>(p => new RemoteInternetSalesService(serviceUrl, SerializationStrategy.Json, false));

            // ProtoBuf serializer
            //service.AddScoped<IInternetSalesService>(p => new RemoteInternetSalesService(serviceUrl, SerializationStrategy.ProtoBuf, false));

            // ProtopBuf + content compression
            //service.AddScoped<IInternetSalesService>(p => new RemoteInternetSalesService(serviceUrl, SerializationStrategy.ProtoBuf, true));
            service.AddTransient<LargeDataViewModel>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var window = new Window();
            this.MainWindow = window;
            window.Title = "Large Data Sample";
            window.Show();
            var serviceCollection = new ServiceCollection();
            OnConfigure(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
            var vm = _serviceProvider.GetService<LargeDataViewModel>();
            window.Content = vm;
            vm.InitializeAsync();
        }
    }
}