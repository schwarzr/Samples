using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Codeworx.Synchronization;
using Microsoft.Extensions.DependencyInjection;

namespace ConstructionDiary.App.ViewModels
{
    public class OfflineStateViewModel : ViewModelBase, IStateViewModel, IProgress<SyncProgress>
    {
        private readonly IServiceProvider _provider;

        private string _syncProgress;

        public OfflineStateViewModel(IServiceProvider provider)
        {
            SwitchCommand = new DelegateCommand(OnSwitch);
            StartSyncCommand = new DelegateCommand(OnStartSync);
            this._provider = provider;
        }

        public string CurrentState => "offline";

        public string Label => "go online";

        public ICommand StartSyncCommand { get; }

        public ICommand SwitchCommand { get; }

        public string SyncProgress
        {
            get { return _syncProgress; }
            private set
            {
                _syncProgress = value;
                RaisePropertyChanged();
            }
        }

        public void Report(SyncProgress value)
        {
            this.SyncProgress = $"{value.Action} - {value.State}";
        }

        private async void OnStartSync()
        {
            var sync = _provider.GetRequiredService<ISyncOrchestration>();

            await sync.RunAsync(this);
        }

        private void OnSwitch()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "diary.sqlite");
            File.Delete(path);
            ((App)App.Current).Initialize();
        }
    }
}