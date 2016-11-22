using Xamarin.Forms;

namespace Baconx
{
    public partial class App : Application
    {
        public static App Instance;

        public App()
        {
            Instance = this;
            ViewModelBase.Init();

            InitializeComponent();
            InitializeNavigation();

            MainPage = new NavigationPage(new MainPage());
        }

        private void InitializeNavigation()
        {
            var navigationService = DependencyService.Get<INavigationService>();
            navigationService.Configure("MainPage", typeof(MainPage));
            navigationService.Configure("DetailPage", typeof(DetailPage));
        }
    }
}
