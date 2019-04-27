using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.App.Attached;
using ConstructionDiary.App.Models;
using ConstructionDiary.Model;

namespace ConstructionDiary.App.ViewModels
{
    [TemplateKey("MenuViewModel")]
    public class MenuViewModel : ViewModelBase
    {
        private readonly ICurrentProjectService _currentProjectService;

        private readonly IProjectController _projectController;

        private ObservableCollection<ProjectInfo> _projects;

        private ProjectInfo _selectedProject;

        public MenuViewModel(INavigationController controller, IProjectController projectController, ICurrentProjectService currentProjectService, IStateViewModel stateViewModel)
        {
            MenuItems = new ObservableCollection<MenuItem>();
            MenuItems.Add(new MenuItem("Areas", new DelegateCommand(() => controller.ShowAsync<AreasViewModel>())));
            this._projectController = projectController;
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

        public async override Task InitializeAsync()
        {
            await base.InitializeAsync();
            var data = await _projectController.GetProjectsAsync();
            Projects = new ObservableCollection<ProjectInfo>(data);
            SelectedProject = _projects.FirstOrDefault();
        }
    }
}