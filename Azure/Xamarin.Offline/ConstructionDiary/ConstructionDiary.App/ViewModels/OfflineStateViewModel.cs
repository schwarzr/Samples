using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;

namespace ConstructionDiary.App.ViewModels
{
    public class OfflineStateViewModel : ViewModelBase, IStateViewModel
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

        private void OnStartSync()
        {
            //var sync = _provider.GetRequiredService<ISyncOrchtestration>();
        }

        private void OnSwitch()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "diary.sqlite");
            File.Delete(path);
            ((App)App.Current).Initialize();
        }
    }
}