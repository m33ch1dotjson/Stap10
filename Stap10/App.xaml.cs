﻿using Stap10.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Stap10
{
    public partial class App : Application
    {
        private readonly MainPage _mainPage;
        public App(MainPage mainPage)
        {
            InitializeComponent();
            _mainPage = mainPage;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}