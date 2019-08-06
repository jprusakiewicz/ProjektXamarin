using System;
using ProjektXamarin.Models;
using Xamarin.Forms;

namespace ProjektXamarin.ViewModels
{
    public class InsuranceDetailViewModel : ContentPage
    {
        public InsuranceDetailViewModel(Insurance item)
        {
            Insurance insurance = item;
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Your Insurance", BindingContext = item }        
                }
            };
        }
    }
}

