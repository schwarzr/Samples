using System;
using System.IO;
using System.Text.Json;
using ConstructionDiary.App.Attached;
using Microsoft.Extensions.Options;

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
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appsettings.json");

            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                var app = new AppSettings { AppOptions = _options };
                await System.Text.Json.JsonSerializer.SerializeAsync(stream, app);
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