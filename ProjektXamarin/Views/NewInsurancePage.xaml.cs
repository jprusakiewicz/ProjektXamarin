using System;
using System.Collections.Generic;
using ProjektXamarin.Models;
using ProjektXamarin.Services;
using Xamarin.Forms;

namespace ProjektXamarin.Views
{
    public partial class NewInsurancePage : ContentPage
    {
        public Insurance Item { get; set; }
        string msg;
        CountInsuranceService service;

        public NewInsurancePage(Customer customer)
        {
            InitializeComponent();
            service = new CountInsuranceService();
            Item = new Insurance
            {
                Id = Guid.NewGuid().ToString(),
                Type = "",
                Prize = 0,
                Duration = 10,
               // owner = customer 
            };
            BindingContext = this;
            if (Item.owner == null)
            {
                Item.owner = new Customer();
                Item.owner.FirstName = customer.FirstName;
                Item.owner.LastName = customer.LastName;
                Item.owner.Adress = customer.Adress;
                Item.owner.Age = customer.Age;
                Item.owner.Education = customer.Education;
                Item.owner.MarialStatus = customer.MarialStatus;
            }
                
            

        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            //tu się podłączyć do serwisu
            //MessagingCenter.Send(this, "AddItem", Item); //albo tu
            MessagingCenter.Send(this, "AddItem", service.CountInsurance(Item));
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
