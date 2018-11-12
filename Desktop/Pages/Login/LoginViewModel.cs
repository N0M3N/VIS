using Desktop.Attributes;
using Desktop.Extensions;
using Desktop.Pages.Home;
using Desktop.Services;
using Reactive.Bindings;
using System;

namespace Desktop.Pages.Login
{
    [ViewModel]
    internal class LoginViewModel : IDisposable
    {
        private readonly INavigationService navigation;
        private readonly MainWindowViewModel mainWIndow;

        public ReactiveProperty<string> Login { get; }
        public ReactiveProperty<string> Password { get; }
        public ReactiveCommand LogInCommand { get; }

        public LoginViewModel(INavigationService navigation, MainWindowViewModel mainWIndow)
        {
            this.navigation = navigation;
            this.mainWIndow = mainWIndow;
            Login = new ReactiveProperty<string>();
            Password = new ReactiveProperty<string>();
            LogInCommand = ReactiveCommandHelper.Create(LoginAction);
        }

        private void LoginAction()
        {
            // TODO: Add login service
            mainWIndow.CurrentUser.Value = new Models.UzivatelModel { JeZamestnanec = true };
            // TODO: Navigate to a page
            navigation.Navigate(new HomeView());
        }

        public void Dispose()
        {
            Login.Dispose();
            Password.Dispose();
            LogInCommand.Dispose();
        }
    }
}
