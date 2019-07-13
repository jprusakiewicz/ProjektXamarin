using System;
using System.Collections.Generic;
using ProjektXamarin.ViewModels;
using Xamarin.Forms;

namespace ProjektXamarin.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            this.BindingContext = new ProfilePageModel();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
