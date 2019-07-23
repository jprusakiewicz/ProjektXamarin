using System;
using System.Collections.Generic;
using ProjektXamarin.Models;
using ProjektXamarin.ViewModels;
using Xamarin.Forms;

namespace ProjektXamarin.Views
{
    public partial class InsuranceDetailPage : ContentPage
    {
        public InsuranceDetailPage(Insurance Item)
        {
            InitializeComponent();
            this.BindingContext = Item ?? throw new System.ArgumentException("pusto byku");
        }
    }
}
