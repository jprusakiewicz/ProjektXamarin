using System;
using System.Collections.Generic;
using ProjektXamarin.ViewModels;
using Xamarin.Forms;

namespace ProjektXamarin.Views
{
    public partial class ProfileEditPage : ContentPage
    {
        public ProfileEditPage(ProfilePageModel profilePageModel)
        {
            InitializeComponent();
            this.BindingContext = profilePageModel;
        }

        async void Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}
