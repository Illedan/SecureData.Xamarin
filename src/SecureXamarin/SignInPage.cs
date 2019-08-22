using System;

using Xamarin.Forms;

namespace SecureXamarin
{
    public class SignInPage : ContentPage
    {
        public SignInPage(Action onLogin)
        {
            Content = new StackLayout
            {
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

