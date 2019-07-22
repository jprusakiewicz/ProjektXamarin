using System;
using ProjektXamarin.Models;
using Xamarin.Forms;

namespace ProjektXamarin.ViewModels
{
    public class InsuranceDetailViewModel : ContentPage
    {
        public InsuranceDetailViewModel(Insurance item)
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

