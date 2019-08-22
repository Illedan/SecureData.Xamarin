using System;

using Xamarin.Forms;

namespace SecureXamarin
{
    public class SplashPage : ContentPage
    {
        private readonly Action onAppearing;

        public SplashPage(Action onAppearing)
        {
            Content = new StackLayout
            {
                Children = {
                    new Label
                    {
                        Text = "Some beautiful image while the user waits for login!",
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.Center
                    }
                }
            };
            this.onAppearing = onAppearing;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            onAppearing();
        }
    }
}

