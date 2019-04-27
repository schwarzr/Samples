using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.App.ViewModels;

namespace ConstructionDiary.App
{
    public interface INavigationController
    {
        Task CloseAsync(ViewModelBase viewModel);

        Task<TViewModel> ShowAsync<TViewModel>()
            where TViewModel : ViewModelBase;
    }
}