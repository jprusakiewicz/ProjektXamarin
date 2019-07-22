using System;
using System.Collections.Generic;
using ProjektXamarin.Models;
using Xamarin.Forms;

namespace ProjektXamarin.Views
{
    public partial class NewInsurancePage : ContentPage
    {
        public Insurance Item { get; set; }

        public NewInsurancePage()
        {
            InitializeComponent();

            Item = new Insurance
            {
                Type = "Car",
                Prize = 5,
                Duration = 10
            };
            BindingContext = this;
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
