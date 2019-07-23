using System;
using System.Collections.Generic;
using ProjektXamarin.Models;
using Xamarin.Forms;

namespace ProjektXamarin.Views
{
    public partial class NewInsurancePage : ContentPage
    {
        public Insurance Item { get; set; }
        string msg;
        bool bom = false;

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

        void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e) //slider
        {
            msg = String.Format("Current value: {0} days", Convert.ToInt32(e.NewValue));
            Item.Duration = Convert.ToInt32(e.NewValue);
            this.text1.Text = msg;
        }

        //void PickerChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) //picker
        //{
        //    // Console.WriteLine(Item.Duration);
        //    C
        //    //if(sender.Equals)
        //    ColorEntry.IsVisible = true;
        //}

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CarEntry.IsVisible = false;
            PropertyEntry.IsVisible = false;
            TripEntry.IsVisible = false;

            if (Item.Type == "Car")
            {
                CarEntry.IsVisible = true;
            }
            if (Item.Type == "Property")
            {
                PropertyEntry.IsVisible = true;
            }
            if (Item.Type == "Trip")
            {
                TripEntry.IsVisible = true;
            }
        }
    }
}
