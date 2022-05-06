using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.App.Attached;
using ConstructionDiary.App.Models;
using ConstructionDiary.Contract;
using ConstructionDiary.Model;
using Microsoft.Extensions.Options;

namespace ConstructionDiary.App.ViewModels
{
    [TemplateKey("MenuViewModel")]
    public class MenuViewModel : ViewModelBase, IDisposable
    {
        private readonly ICurrentProjectService _currentProjectService;

        private readonly INavigationController _navigationController;

        private readonly IProjectService _projectService;

        private readonly IDisposable _subscription;

        private bool _disposedValue = false;

        private ObservableCollection<ProjectInfo> _projects;

        private ProjectInfo _selectedProject;

        public MenuViewModel(INavigationController controller,
            IProjectService projectController,
            ICurrentProjectService currentProjectService,
            IStateViewModel stateViewModel,
            IOptionsMonitor<AppOptions> monitor)
        {
            _subscription = monitor.OnChange(async p => await InitializeAsync());

            MenuItems = new ObservableCollection<MenuItem>();
            MenuItems.Add(new MenuItem("Areas", new DelegateCommand(() => controller.ShowAsync<AreasViewModel>())));
            MenuItems.Add(new MenuItem("Settings", new DelegateCommand(() => controller.ShowAsync<SettingsViewModel>())));

            this._navigationController = controller;
            this._projectService = projectController;
            this._currentProjectService = currentProjectService;
            this.StateViewModel = stateViewModel;
        }

        public ObservableCollection<MenuItem> MenuItems { get; }

        public ObservableCollection<ProjectInfo> Projects
        {
            get { return _projects; }
            private set
            {
                if (_projects != value)
                {
                    _projects = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ProjectInfo SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                if (_selectedProject != value)
                {
                    _selectedProject = value;
                    RaisePropertyChanged();
                    _currentProjectService.Change(_selectedProject);
                }
            }
        }

        public IStateViewModel StateViewModel { get; }

        public void Dispose()
        {
            Dispose(true);
        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            this.Projects = null;
            this.SelectedProject = null;

            try
            {
                var data = await _projectService.GetProjectsAsync();
                Projects = new ObservableCollection<ProjectInfo>(data);
                SelectedProject = data.FirstOrDefault();
            }
            catch (Exception)
            {
                await _navigationController.ShowAsync<SettingsViewModel>();
            }
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
    }
}