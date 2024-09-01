﻿using AppFakeStore.Services;
using AppFakeStore.ViewModels;
using AppFakeStore.Views;

namespace AppFakeStore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();            
            //MainPage = new AppShell();
            MainPage = new NavigationPage(new MainPage());
            ShowLoginPage();
        }

        private async void ShowLoginPage()
        {
            await MainPage.Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
        }
    }
}
