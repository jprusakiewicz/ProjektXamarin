﻿using System;
using ProjektXamarin.Services;
using ProjektXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
