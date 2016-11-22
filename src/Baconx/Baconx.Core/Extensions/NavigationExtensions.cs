using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Baconx
{
    //based on https://marcominerva.wordpress.com/2016/07/11/a-simple-navigationservice-for-xamarin-forms/
    public static class NavigationExtensions
    {
        private static ConditionalWeakTable<Page, object> arguments = new ConditionalWeakTable<Page, object>();

        public static object NavigationArgs(this Page page)
        {
            object argument = null;
            arguments.TryGetValue(page, out argument);

            return argument;
        }

        public static void AddNavigationArgs(this Page page, object args) => arguments.Add(page, args);
    }
}
