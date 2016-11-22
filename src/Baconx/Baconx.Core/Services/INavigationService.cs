using System;
using System.Threading.Tasks;

namespace Baconx
{
    public enum NavigationBehavior
    {
        Default,
        ClearBackstak
    }

    public interface INavigationService
    {
        Task Go(string pageKey, object parameter = null, NavigationBehavior navigationBehavior = NavigationBehavior.Default);
        Task Back();
        void Configure(string key, Type pageType);
    }
}
