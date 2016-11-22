using System;
using Xamarin.Forms;

namespace Baconx
{
    public class BaseView<TViewModel> : ContentPage where TViewModel : ViewModelBase
    {
        TViewModel vm;
        public TViewModel ViewModel => vm ?? (vm = BindingContext as TViewModel);

    }
}
