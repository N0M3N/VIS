using Desktop.Attributes;
using Desktop.Utils;
using Desktop.Connector;
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
        private readonly IUzivatelConnector uzivatelConnector;
        private readonly MainWindowViewModel mainWIndow;

        public ReactiveProperty<string> Login { get; }
        public ReactiveProperty<string> Password { get; }
        public ReactiveCommand LogInCommand { get; }

        public LoginViewModel(INavigationService navigation, IUzivatelConnector uzivatelConnector, MainWindowViewModel mainWIndow)
        {
            this.navigation = navigation;
            this.uzivatelConnector = uzivatelConnector;
            this.mainWIndow = mainWIndow;
            Login = new ReactiveProperty<string>();
            Password = new ReactiveProperty<string>();
            LogInCommand = ReactiveCommandHelper.Create(LoginAction);
        }

        private async void LoginAction()
        {
            var user = await uzivatelConnector.Login(Login.Value, Password.Value);
            if(user != null)
            {
                mainWIndow.CurrentUser.Value = user;
                navigation.Navigate(new HomeView());
            }
        }

        public void Dispose()
        {
            Login.Dispose();
            Password.Dispose();
            LogInCommand.Dispose();
        }
    }
}
