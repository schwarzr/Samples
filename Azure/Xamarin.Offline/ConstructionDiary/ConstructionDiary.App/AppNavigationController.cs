using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ConstructionDiary.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ConstructionDiary.App
{
    public class AppNavigationController : INavigationController
    {
        private readonly ObservableCollection<ViewModelBase> _navigationStack;

        private readonly IServiceProvider _serviceProvider;

        public AppNavigationController(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;

            this._navigationStack = new ObservableCollection<ViewModelBase>();
            this._navigationStack.CollectionChanged += _navigationStack_CollectionChanged;
        }

        public event Action<ViewModelBase> Added;

        public event Action<ViewModelBase> Removed;

        public IEnumerable<ViewModelBase> Stack => _navigationStack;

        public async Task CloseAsync(ViewModelBase viewModel)
        {
            _navigationStack.Remove(viewModel);

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

            _navigationStack.Add(viewModel);
            return viewModel;
        }

        private void _navigationStack_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    Removed?.Invoke((ViewModelBase)item);
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    Added?.Invoke((ViewModelBase)item);
                }
            }
        }
    }
}