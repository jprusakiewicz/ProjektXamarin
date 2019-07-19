using System;
using System.Collections.Generic;
using ProjektXamarin.ViewModels;
using Xamarin.Forms;

namespace ProjektXamarin.Views
{
    public partial class ProfilePage : ContentPage
    {
        ProfilePageModel prof;
        public ProfilePage()
        {
            InitializeComponent();
            prof = new ProfilePageModel();
            this.BindingContext = prof;
        }

        async void EditProfile_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ProfileEditPage(prof)));
        }
    }
}
