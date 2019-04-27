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

        public ApplicationViewModel(MenuViewModel menu, INavigationController navigation)
        {
            this.Menu = menu;
            this.Navigation = navigation;
            this.Navigation.ShowAsync<DashboardViewModel>();
        }

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

        public INavigationController Navigation { get; }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            await Menu.InitializeAsync();
        }
    }
}