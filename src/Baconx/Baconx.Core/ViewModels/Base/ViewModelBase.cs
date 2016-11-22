using System;
using Baconx.Helpers;
using MvvmHelpers;
using PropertyChanged;
using Xamarin.Forms;

namespace Baconx
{
    [ImplementPropertyChanged]
    public class ViewModelBase : BaseViewModel
    {
        INavigationService _navigationService;
        public INavigationService NavigationService
            => _navigationService ?? (_navigationService = DependencyService.Get<INavigationService>());

        public Settings Settings
        {
            get { return Settings.Current; }
        }

        public ViewModelBase(string title = "")
        {
            Title = title;
        }

        public static void Init()
        {
            DependencyService.Register<INavigationService, NavigationService>();
        }
    }
}
