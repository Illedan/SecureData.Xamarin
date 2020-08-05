using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SecureXamarin
{
    public class SignInPage : ContentPage
    {
        private bool hasLoggedOut;
        private readonly Action showSignIn;

        public SignInPage(Action onLogin, Action showSignIn)
        {
            //On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FullScreen);
            var grid = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Red,
                Margin= new Thickness(50),
                Children = {
                    new Button
                    {
                        Text = "Sign in!",
                        Command = new Command(()=>{
                            hasLoggedOut = true;
                          //  ((Xamarin.Forms.NavigationPage)(Xamarin.Forms.Application.Current.MainPage)).Navigation.NavigationStack.Last().IsVisible = true;
                            onLogin();
                        }),
                        VerticalOptions = LayoutOptions.Center
                    },
                    new Button
                    {
                        Text = "Sign in sneaky!",
                        Command = new Command(()=>{
                            //hasLoggedOut = true;
                            onLogin();
                        }),
                        VerticalOptions = LayoutOptions.Center
                    }
                }
            };

            Content = grid;
            this.showSignIn = showSignIn;
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            if (!hasLoggedOut)
            {
                showSignIn();
            }
            else
            {
               // ((Xamarin.Forms.NavigationPage)(Xamarin.Forms.Application.Current.MainPage)).Navigation.NavigationStack.Last().IsVisible = true;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            hasLoggedOut = false;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}

