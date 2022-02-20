using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using ConstructionDiary.Contract;

namespace ConstructionDiary.App.ViewModels
{
    public class OnlineStateViewModel : IStateViewModel
    {
        private readonly ICurrentProjectService _currentProject;

        private readonly IOfflineService _service;

        public OnlineStateViewModel(IOfflineService service, ICurrentProjectService currentProject)
        {
            SwitchCommand = new DelegateCommand(OnSwitch);
            StartSyncCommand = new DelegateCommand(() => { }, () => false);
            this._service = service;
            this._currentProject = currentProject;
        }

        public string CurrentState => "online";

        public string Label => "go offline";

        public ICommand StartSyncCommand { get; }

        public ICommand SwitchCommand { get; }

        public string SyncProgress => null;

        private async void OnSwitch()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "diary.sqlite");
            var data = await _service.GetOfflineDBAsync(_currentProject.Current.Id);
            File.WriteAllBytes(path, data);

            ((App)App.Current).Initialize();
        }
    }
}