using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConstructionDiary.App.Attached;
using ConstructionDiary.Contract;
using ConstructionDiary.Model;

namespace ConstructionDiary.App.ViewModels
{
    [TemplateKey("CreateIssue")]
    public class CreateIssueViewModel : ViewModelBase
    {
        private readonly INavigationController _navigation;

        private readonly IIssueService _service;

        private AreaInfo _area;

        private string _description;

        private ObservableCollection<EmployeeInfo> _employees;

        private ObservableCollection<IssueTypeInfo> _issueTypes;

        private EmployeeInfo _selectedEmployee;

        private IssueTypeInfo _selectedIssueType;

        private string _title;

        public CreateIssueViewModel(IIssueService controller, INavigationController navigation)
        {
            this._service = controller;
            this._navigation = navigation;
            IssueTypes = new ObservableCollection<IssueTypeInfo>();
            Employees = new ObservableCollection<EmployeeInfo>();

            Attachments = new ObservableCollection<byte[]>();

            SaveCommand = new DelegateCommand(DoSave);
            CancelCommand = new DelegateCommand(DoCancel);
        }

        public AreaInfo Area
        {
            get { return _area; }
            private set
            {
                if (_area != value)
                {
                    _area = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ObservableCollection<byte[]> Attachments { get; }

        public ICommand CancelCommand { get; }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ObservableCollection<EmployeeInfo> Employees
        {
            get { return _employees; }
            private set
            {
                if (_employees != value)
                {
                    _employees = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ObservableCollection<IssueTypeInfo> IssueTypes
        {
            get { return _issueTypes; }
            private set
            {
                if (_issueTypes != value)
                {
                    _issueTypes = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand SaveCommand { get; }

        public EmployeeInfo SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                if (_selectedEmployee != value)
                {
                    _selectedEmployee = value;
                    RaisePropertyChanged();
                }
            }
        }

        public IssueTypeInfo SelectedIssueType
        {
            get { return _selectedIssueType; }
            set
            {
                if (_selectedIssueType != value)
                {
                    _selectedIssueType = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged();
                }
            }
        }

        public async Task SetAreaAsync(AreaInfo value, ProjectInfo current)
        {
            Area = value;
            var data = await _service.GetIssueCreateAsync(current.Id);
            Employees = new ObservableCollection<EmployeeInfo>(data.Employees);
            IssueTypes = new ObservableCollection<IssueTypeInfo>(data.IssueTypes);
        }

        private void DoCancel()
        {
            _navigation.CloseAsync(this);
        }

        private async void DoSave()
        {
            var issueData = new IssueCreateItem
            {
                AreaId = this.Area.Id,
                AssignedToId = this.SelectedEmployee?.Id,
                CreationTime = DateTime.Now,
                Descripton = this.Description,
                Title = this.Title,
                IssueTypeId = SelectedIssueType.Id
            };

            await _service.CreateIssueAsync(issueData);

            await _navigation.CloseAsync(this);
        }
    }
}