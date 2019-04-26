using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ConstructionDiary.App.Models;
using ConstructionDiary.Api.Client;
using ConstructionDiary.Api.Contract;
using ConstructionDiary.AspNetCore.Client;
using ConstructionDiary.Model;

namespace ConstructionDiary.App.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        public Item Item { get; set; }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            var client = new CountryControllerClient(new RestOptions<ICountryController>("http://192.168.1.26:5001/"));

            await client.InsertCountryAsync(new CountryListItem { IsoTwo = this.Item.Text, Name = this.Item.Description });
            await Navigation.PopModalAsync();
        }
    }
}