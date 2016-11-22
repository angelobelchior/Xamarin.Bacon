using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Baconx
{
    public partial class MainPage : ContentPage
    {
        MainViewModel vm;
        public MainViewModel ViewModel => vm ?? (vm = BindingContext as MainViewModel);

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
