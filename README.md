# SecureData.Xamarin
Proof of concept for securing data during app lifecycles.
Problem this solves is to hide data at every point of viewing the app after it sleeps:
- App switcher
- When app is opened, before biometrics verification.


## Android

In MainActivity, add:
`Window.SetFlags(WindowManagerFlags.Secure, WindowManagerFlags.Secure);`


## iOS

Need no further work

## Xamarin.Forms

### OnSleep
Hide your outermost page / the whole navigationPage.

### OnResume
Navigate the navigation page to another page of some kind. (will not matter if you hide the whole navigationpage.)
But you need the OnAppearing callback of this, as this proves the app is ready to swap `MainPage`.

### OnAppearing of splashPage
Change `MainPage` to your login page. Change `MainPage` by using `Xamarin.Essentials.MainThread.BeginInvokeOnMainThread`.

### After user authenticated
- Pop away the outermost page of the navigation stack.
- Show your outermost page / the whole navigationPage.
- Change `MainPage` to your navigation page again.
    - Change `MainPage` by using `Xamarin.Essentials.MainThread.BeginInvokeOnMainThread`.