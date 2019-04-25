using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ConstructionDiary.App.Models;
using ConstructionDiary.App.Views;
using ConstructionDiary.AspNetCore.Client;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.Model;

namespace ConstructionDiary.App.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<UserInfo>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                //Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        public ObservableCollection<UserInfo> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                var client = new RestClient<IUserController>(new RestOptions<IUserController>("http://10.41.8.22:5001/"));
                var result = await client.CallAsync(p => p.GetAllUserInfosAsync());

                foreach (var item in result)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}