using System;
using Xamarin.Forms;
using ConstructionDiary.App.Views;
using ConstructionDiary.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using ConstructionDiary.App.Bootstrap;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace ConstructionDiary.App
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            InitializeComponent();

            Initialize();
        }

        internal void Initialize()
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var settingsPath = Path.Combine(basePath, "appsettings.json");

            if (!File.Exists(settingsPath))
            {
                File.WriteAllText(settingsPath, "{}");
            }

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", false, false);
            var config = builder.Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConfiguration>(config);
            serviceCollection.Configure<AppOptions>(config.GetSection("AppOptions"));

            var path = Path.Combine(basePath, "diary.sqlite");

            if (File.Exists(path))
            {
                Local.Register(serviceCollection);
            }
            else
            {
                Remote.Register(serviceCollection);
            }

            _serviceProvider = serviceCollection.BuildServiceProvider();

            var view = new ShellView();
            var vm = _serviceProvider.GetRequiredService<ApplicationViewModel>();
            view.BindingContext = vm;
            var t = vm.InitializeAsync();
            this.MainPage = view;
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }
    }
}