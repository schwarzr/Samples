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
using ConstructionDiary.Api.Client;

namespace ConstructionDiary.App.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<CountryInfo>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                //Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        public ObservableCollection<CountryInfo> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                var client = new CountryControllerClient(new RestOptions<ICountryController>("http://192.168.1.26:5001/"));
                var result = await client.GetCountryInfosAsync();

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