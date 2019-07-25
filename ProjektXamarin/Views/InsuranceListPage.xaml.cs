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
            await Navigation.PushModalAsync(new NavigationPage(new NewInsurancePage(viewModel.customer)));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
