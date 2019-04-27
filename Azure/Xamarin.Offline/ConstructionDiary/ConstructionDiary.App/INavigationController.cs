using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.App.ViewModels;

namespace ConstructionDiary.App
{
    public interface INavigationController
    {
        event Action<ViewModelBase> Added;

        event Action<ViewModelBase> Removed;

        IEnumerable<ViewModelBase> Stack { get; }

        Task CloseAsync(ViewModelBase viewModel);

        Task<TViewModel> ShowAsync<TViewModel>()
            where TViewModel : ViewModelBase;
    }
}