using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Baconx
{
    public partial class DetailPage : ContentPage
    {
        DetailViewModel vm;
        public DetailViewModel ViewModel => vm ?? (vm = BindingContext as DetailViewModel);

        public DetailPage()
        {
            InitializeComponent();
            BindingContext = new DetailViewModel();
        }
    }
}
