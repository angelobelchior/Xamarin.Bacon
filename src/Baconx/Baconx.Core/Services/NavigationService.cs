using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Baconx
{
    public static class NavigationExtensions
    {
        private static ConditionalWeakTable<Page, object> arguments = new ConditionalWeakTable<Page, object>();

        public static object GetNavigationArgs(this Page page)
        {
            object argument = null;
            arguments.TryGetValue(page, out argument);

            return argument;
        }

        public static void SetNavigationArgs(this Page page, object args) => arguments.Add(page, args);
    }

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

    public class NavigationService : INavigationService
    {
        Dictionary<string, Type> pages { get; } = new Dictionary<string, Type>();
        public Page MainPage => Application.Current.MainPage;

        public async Task Back() => await MainPage.Navigation.PopAsync();

        public void Configure(string key, Type pageType) => pages[key] = pageType;

        public async Task Go(string pageKey, object parameter = null, NavigationBehavior navigationBehavior = NavigationBehavior.Default)
        {
            Type pageType;

            if (pages.TryGetValue(pageKey, out pageType))
            {
                var displayPage = (Page)Activator.CreateInstance(pageType);
                displayPage.SetNavigationArgs(parameter);

                if (navigationBehavior == NavigationBehavior.ClearBackstak)
                {
                    MainPage.Navigation.InsertPageBefore(displayPage, MainPage.Navigation.NavigationStack[0]);

                    var existingPages = MainPage.Navigation.NavigationStack.ToList();

                    for (int i = 1; i < existingPages.Count; i++)
                        MainPage.Navigation.RemovePage(existingPages[i]);
                }
                else
                {
                    await MainPage.Navigation.PushAsync(displayPage);
                }
            }
            else
            {
                throw new ArgumentException($"Page : {pageKey} not found!", nameof(pageKey));
            }
        }
    }
}
