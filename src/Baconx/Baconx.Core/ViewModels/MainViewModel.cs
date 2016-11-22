using System;
using System.Windows.Input;
using Baconx.Helpers;
using PropertyChanged;
using Xamarin.Forms;

namespace Baconx
{
    [ImplementPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        ICommand detailCommand;
        public ICommand DetailCommand =>
            detailCommand ?? (detailCommand = new Command(async () => await NavigationService.Go("DetailPage")));

        public MainViewModel() : base(Resources.MainViewModelTitle)
        {
        }
    }
}
