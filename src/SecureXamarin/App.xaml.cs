using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecureXamarin
{
    public partial class App : Application
    {
        private SignInPage signInPage;
        private NavigationPage navigationPage;
        private SplashPage splashPage;

        public App()
        {
            InitializeComponent();
            signInPage = new SignInPage(OnSignIn);
            splashPage = new SplashPage(OnSplashAppearing);
            MainPage = navigationPage = new NavigationPage(new MainPage());
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
        }

        private void OnSplashAppearing()
        {
            MainPage = signInPage;
        }
    }
}
