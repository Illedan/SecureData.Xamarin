using System;
using System.Linq;
using System.Runtime.InteropServices;
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
        //private SplashPage splashPage;

        public App()
        {
            InitializeComponent();
            signInPage = new SignInPage(OnSignIn);
            //splashPage = new SplashPage(OnSplashAppearing);
            navigationPage = new Xamarin.Forms.NavigationPage(new MainPage());
            navigationPage.On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FullScreen);
            navigationPage.On<iOS>().SetUseSafeArea(true);
            MainPage = navigationPage;
            _ = navigationPage.Navigation.PushModalAsync(signInPage);
        }

        protected override async void OnStart()
        {
        }

        protected override async void OnSleep()
        {
            if(signInPage.Parent == null)
                await navigationPage.Navigation.PushModalAsync(signInPage);

            //navigationPage.IsVisible = false;
        }

        protected override async void OnResume()
        {
            //await navigationPage.Navigation.PushModalAsync(signInPage);

            //try
            //{
            //    splashPage);
            //}
            //catch (Exception e)
            //{
            //    // Log it. 
            //}
        }

        private async void OnSignIn()
        {
            //while (navigationPage.Navigation.NavigationStack.OfType<SplashPage>().Any())
            //{
            //    await Task.Delay(200);
            //    navigationPage.Navigation.RemovePage(navigationPage.Navigation.NavigationStack.OfType<SplashPage>().First());
            //}
            //await navigationPage.Navigation.PopAsync();

            await navigationPage.Navigation.PopModalAsync();
            //navigationPage.IsVisible = true;
            //Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
            //{
            //    MainPage = navigationPage;
            //});
        }

        private async void OnSplashAppearing()
        {
            await navigationPage.Navigation.PushModalAsync(signInPage);
            //Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
            //{
            //    MainPage = signInPage;
            //});
        }
    }
}
