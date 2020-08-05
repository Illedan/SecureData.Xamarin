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
        private Xamarin.Forms.TabbedPage tabbedPage;
        //private SplashPage splashPage;

        public App()
        {
            InitializeComponent();
            signInPage = new SignInPage(OnSignIn, OnSleep);
            //splashPage = new SplashPage(OnSplashAppearing);
            tabbedPage = new Xamarin.Forms.TabbedPage();
            tabbedPage.Children.Add(new MainPage());
            //navigationPage.On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FullScreen);
            tabbedPage.On<iOS>().SetUseSafeArea(true);
            MainPage = tabbedPage;
           // _ = navigationPage.Navigation.PushModalAsync(new MainPage());
            _ = tabbedPage.Navigation.PushModalAsync(signInPage);
        }

        protected override async void OnStart()
        {
           // ((Xamarin.Forms.TabbedPage)(Xamarin.Forms.Application.Current.MainPage)).Navigation.NavigationStack.Last().IsVisible = false;
        }

        protected override async void OnSleep()
        {
           // ((Xamarin.Forms.NavigationPage)(Xamarin.Forms.Application.Current.MainPage)).Navigation.NavigationStack.Last().IsVisible = false;
            if (signInPage.Parent == null)
                await tabbedPage.Navigation.PushModalAsync(signInPage);

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

            await tabbedPage.Navigation.PopModalAsync();
            //navigationPage.IsVisible = true;
            //Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
            //{
            //    MainPage = navigationPage;
            //});
        }

        private async void OnSplashAppearing()
        {
            await tabbedPage.Navigation.PushModalAsync(signInPage);
            //Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
            //{
            //    MainPage = signInPage;
            //});
        }
    }
}
