using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Baconx
{
    public class NavigationService : INavigationService
    {
        Dictionary<string, Type> PagesDictionary { get; } = new Dictionary<string, Type>();
        public Page MainPage => Application.Current.MainPage;

        public async Task Back() => await MainPage.Navigation.PopAsync();

        public void Configure(string key, Type pageType) => PagesDictionary[key] = pageType;

        public async Task Go(string pageKey, object parameter = null, NavigationBehavior navigationBehavior = NavigationBehavior.Default)
        {
            Type pageType;

            if (PagesDictionary.TryGetValue(pageKey, out pageType))
            {
                var page = (Page)Activator.CreateInstance(pageType);
                page.AddNavigationArgs(parameter);

                if (navigationBehavior == NavigationBehavior.ClearBackstak)
                {
                    MainPage.Navigation.InsertPageBefore(page, MainPage.Navigation.NavigationStack.FirstOrDefault());

                    var pages = MainPage.Navigation.NavigationStack.ToList();

                    for (int i = 1; i < pages.Count; i++)
                        MainPage.Navigation.RemovePage(pages[i]);
                }
                else
                {
                    await MainPage.Navigation.PushAsync(page);
                }
            }
            else
            {
                throw new ArgumentException($"Page : {pageKey} not found!", nameof(pageKey));
            }
        }
    }
}
