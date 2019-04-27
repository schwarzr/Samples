using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ConstructionDiary.App
{
    public class AppNavigationController : INavigationController
    {
        private readonly ApplicationViewModel _appViewModel;

        private readonly IServiceProvider _serviceProvider;

        public AppNavigationController(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public async Task CloseAsync(ViewModelBase viewModel)
        {
            var appViewModel = _serviceProvider.GetRequiredService<ApplicationViewModel>();

            appViewModel.RemoveDetail(viewModel);

            if (viewModel is IDisposable disp)
            {
                disp.Dispose();
            }
        }

        public async Task<TViewModel> ShowAsync<TViewModel>()
            where TViewModel : ViewModelBase
        {
            var viewModel = _serviceProvider.GetRequiredService<TViewModel>();

            await viewModel.InitializeAsync();

            var appViewModel = _serviceProvider.GetRequiredService<ApplicationViewModel>();

            appViewModel.AddAndShowDetail(viewModel);

            return viewModel;
        }
    }
}