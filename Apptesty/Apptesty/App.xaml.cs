﻿using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Apptesty
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Preferences.Get("MyFirebaseRefreshToken", "")))
            {
                MainPage = new NavigationPage(new CarouselPage());
            }
            else
            {
                // MainPage = new NavigationPage(new OnePage());
                MainPage = new NavigationPage(new CarouselPage());
            }

            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
