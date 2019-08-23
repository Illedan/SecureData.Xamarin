using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace SecureXamarin
{
    public partial class App : Xamarin.Forms.Application
    {
        private SignInPage signInPage;
        private Xamarin.Forms.NavigationPage navigationPage;
        private SplashPage splashPage;

        public App()
        {
            InitializeComponent();
            signInPage = new SignInPage(OnSignIn);
            splashPage = new SplashPage(OnSplashAppearing);
            MainPage = signInPage;
            navigationPage = new Xamarin.Forms.NavigationPage(new MainPage());
            navigationPage.On<iOS>().SetUseSafeArea(true);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            navigationPage.IsVisible = false;
        }

        protected override async void OnResume()
        {
            try
            {
                await navigationPage.Navigation.PushAsync(splashPage);
            }
            catch (Exception e)
            {
                // Log it. 
            }
        }

        private async void OnSignIn()
        {
            await navigationPage.Navigation.PopAsync();

            navigationPage.IsVisible = true;
            MainPage = navigationPage;
            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
            {
                MainPage = navigationPage;
            });
        }

        private async void OnSplashAppearing()
        {
            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
            {
                MainPage = signInPage;
            });
        }
    }
}
