using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProjektXamarin.Models;
using ProjektXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektXamarin.Views
{
    public partial class InsuranceListPage : ContentPage
    {
        InsuranceListViewModel viewModel;

        public InsuranceListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new InsuranceListViewModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Insurance;
            if (item == null)
                return;

            //await Navigation.PushAsync(new InsuranceDetailPage(new InsuranceDetailViewModel(item)));
            await Navigation.PushAsync(new InsuranceDetailPage(item));
            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (viewModel.IsCustomerreplete())
                await Navigation.PushModalAsync(new NavigationPage(new NewInsurancePage(viewModel.customer)));
            else
                await DisplayAlert("Profile is empty","Please edit your profile","OK");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            var item = (MenuItem)sender;
            string id = item.CommandParameter.ToString();
            Console.WriteLine(id);
            await viewModel.DataStore.DeleteItemAsync(id);
            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
