using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionDiary.App.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        private ViewModelBase _menu;

        private ViewModelBase _selectedDetail;

        public ApplicationViewModel(MenuViewModel menu, DashboardViewModel dashboard)
        {
            this.DetailStack = new ObservableCollection<ViewModelBase>();
            this.Menu = menu;
            this.DetailStack.Add(dashboard);
            this.SelectedDetail = this.DetailStack.First();
        }

        public ObservableCollection<ViewModelBase> DetailStack { get; }

        public ViewModelBase Menu
        {
            get { return _menu; }
            private set
            {
                if (_menu != value)
                {
                    _menu = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ViewModelBase SelectedDetail
        {
            get { return _selectedDetail; }
            private set
            {
                if (_selectedDetail != value)
                {
                    _selectedDetail = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void AddAndShowDetail(ViewModelBase viewModel)
        {
            this.DetailStack.Add(viewModel);
            this.SelectedDetail = viewModel;
        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            await Menu.InitializeAsync();
            await SelectedDetail.InitializeAsync();
        }

        public void RemoveDetail(ViewModelBase viewModel)
        {
            this.DetailStack.Remove(viewModel);

            if (this.SelectedDetail == viewModel)
            {
                this.SelectedDetail = this.DetailStack.LastOrDefault();
            }
        }
    }
}