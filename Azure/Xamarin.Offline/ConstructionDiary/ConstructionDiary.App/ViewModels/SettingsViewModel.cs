using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.App.Attached;
using ConstructionDiary.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ConstructionDiary.App.ViewModels
{
    [TemplateKey("Settings")]
    public class SettingsViewModel : ViewModelBase, IDisposable
    {
        private readonly INavigationController _controller;

        private readonly IOptionsMonitor<AppOptions> _monitor;

        private readonly IDisposable _subscription;

        private bool _disposedValue = false;

        private AppOptions _options;

        public SettingsViewModel(IOptionsMonitor<AppOptions> monitor, INavigationController controller)
        {
            _monitor = monitor;
            _controller = controller;
            _subscription = _monitor.OnChange(p => _options = p);
            _options = _monitor.CurrentValue;

            SaveCommand = new DelegateCommand(Save);
        }

        public AppOptions Options
        {
            get { return _options; }
            set
            {
                if (_options != value)
                {
                    _options = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DelegateCommand SaveCommand { get; }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _subscription.Dispose();
                }

                _disposedValue = true;
            }
        }

        private async void Save()
        {
            var serializer = JsonSerializer.Create();

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appsettings.json");

            using (var sw = new StreamWriter(path))
            using (var jw = new JsonTextWriter(sw))
            {
                var app = new AppSettings { AppOptions = _options };

                serializer.Serialize(jw, app);
            }

            await _controller.CloseAsync(this);

            ((App)App.Current).Initialize();
        }

        private class AppSettings
        {
            public AppOptions AppOptions { get; set; }
        }
    }
}