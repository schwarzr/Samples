using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace ConstructionDiary.App.ViewModels
{
    public class OfflineStateViewModel : IStateViewModel
    {
        public OfflineStateViewModel()
        {
            SwitchCommand = new DelegateCommand(OnSwitch);
        }

        public string CurrentState => "offline";

        public string Label => "go online";

        public ICommand SwitchCommand { get; }

        private void OnSwitch()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "diary.sqlite");
            File.Delete(path);
            ((App)App.Current).Initialize();
        }
    }
}