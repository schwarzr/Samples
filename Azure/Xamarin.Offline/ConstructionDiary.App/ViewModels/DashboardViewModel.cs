using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ConstructionDiary.App.Attached;
using ConstructionDiary.Contract;
using ConstructionDiary.Model;
using ConstructionDiary.Service;

namespace ConstructionDiary.App.ViewModels
{
    [TemplateKey("Dashboard")]
    public class DashboardViewModel : ViewModelBase, IDisposable
    {
        private readonly ICurrentProjectService _currentProjectService;

        private readonly IIssueService _issueService;

        private readonly IDisposable _subscription;

        private bool _disposedValue;

        private ObservableCollection<IssueListItem> _items;

        public DashboardViewModel(ICurrentProjectService currentProjectService, IIssueService issueService, INavigationController navigation)
        {
            _issueService = issueService;
            _currentProjectService = currentProjectService;
            _subscription = currentProjectService.Register(ProjectChanged);
        }

        public ObservableCollection<IssueListItem> Items
        {
            get { return _items; }
            private set
            {
                if (_items != value)
                {
                    _items = value;
                }
                RaisePropertyChanged(nameof(Items));
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async Task ReloadAsync()
        {
            await LoadDataAsync(_currentProjectService.Current.Id);
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
            var data = await _issueService.GetIssuesAsync(_currentProjectService.Current.Id, 0, 10, 10);
            Items = new ObservableCollection<IssueListItem>(data.Items);
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

        private void ProjectChanged(ProjectInfo obj)
        {
            LoadDataAsync(obj.Id).Invoke();
        }
    }
}