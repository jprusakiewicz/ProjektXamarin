using System;
using System.Collections.Generic;
using ProjektXamarin.Models;
using Xamarin.Forms;

namespace ProjektXamarin.Views
{
    public partial class NewInsurancePage : ContentPage
    {
        public Insurance Item { get; set; }
        string msg = "here";

        public NewInsurancePage()
        {
            InitializeComponent();

            Item = new Insurance
            {
                Id = Guid.NewGuid().ToString(),
                Type = "",
                Prize = 0,
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

        void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            msg = String.Format("Current value: {0} days", Convert.ToInt32(e.NewValue));
            Item.Duration = Convert.ToInt32(e.NewValue);
            this.text1.Text = msg;
        }
    }
}
