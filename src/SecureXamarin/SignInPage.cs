using System;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SecureXamarin
{
    public class SignInPage : ContentPage
    {
        public SignInPage(Action onLogin)
        {
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    new Button
                    {
                        Text = "Sign in!",
                        Command = new Command(onLogin),
                        VerticalOptions = LayoutOptions.Center
                    }
                }
            };
        }
    }
}

