using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConstructionDiary.App.Attached;
using ConstructionDiary.Contract;
using ConstructionDiary.Model;

namespace ConstructionDiary.App.ViewModels
{
    [TemplateKey("Areas")]
    public class AreasViewModel : ViewModelBase, IDisposable
    {
        private readonly IAreaService _areaController;

        private readonly ICurrentProjectService _currentProjectService;

        private readonly INavigationController _navigation;

        private readonly IDisposable _subscription;

        private ObservableCollection<CommandWrapper> _areas;

        public AreasViewModel(ICurrentProjectService currentProjectService, IAreaService areaController, INavigationController navigation)
        {
            this._currentProjectService = currentProjectService;
            this._areaController = areaController;
            this._navigation = navigation;
            _subscription = _currentProjectService.Register(OnProjectChanged);
            Areas = new ObservableCollection<CommandWrapper>();
            CreateIssueCommand = new DelegateCommand<AreaInfo>(CreateIssue);
        }

        public ObservableCollection<CommandWrapper> Areas
        {
            get { return _areas; }
            private set
            {
                if (_areas != value)
                {
                    _areas = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand CreateIssueCommand { get; }

        public void Dispose()
        {
            _subscription?.Dispose();
        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            if (_currentProjectService.Current != null)
            {
                await LoadDataAsync(_currentProjectService.Current.Id);
            }
        }

        public async Task LoadDataAsync(Guid projectId)
        {
            var data = await _areaController.GetAreaInfosAsync(projectId);
            Areas = new ObservableCollection<CommandWrapper>(data.Select(p => new CommandWrapper { Item = p, Command = CreateIssueCommand }));
        }

        private async void CreateIssue(AreaInfo value)
        {
            var vm = await _navigation.ShowAsync<CreateIssueViewModel>();
            await vm.SetAreaAsync(value, _currentProjectService.Current);
        }

        private void OnProjectChanged(ProjectInfo obj)
        {
            var t = LoadDataAsync(obj.Id);
        }

        public class CommandWrapper
        {
            public ICommand Command { get; set; }

            public AreaInfo Item { get; set; }
        }
    }
}