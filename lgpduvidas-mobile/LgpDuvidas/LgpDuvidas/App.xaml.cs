using LgpDuvidas.Data;
using LgpDuvidas.Helpers;
using LgpDuvidas.Interfaces;
using LgpDuvidas.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LgpDuvidas
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<WatsonAssistantService>();
            DependencyService.Register<AnalyticsService>();

            DependencyService.Register<AuthService>();
            DependencyService.Register<DbContext>();

            if (Device.RuntimePlatform == Device.iOS)
            {
                //iOS stuff
            }
            if (Device.RuntimePlatform == Device.Android)
            {
                DependencyService.Register<DroidKeyboardHelper>();
            }

            MainPage = new AppShell();
            Shell.Current.GoToAsync("//LoginPage");             
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
