using Desktop.Attributes;
using Desktop.Utils;
using Desktop.Connector;
using Desktop.Pages.Home;
using Desktop.Services;
using Reactive.Bindings;
using System;
using Models;

namespace Desktop.Pages.Login
{
    [ViewModel]
    internal class LoginViewModel : IDisposable
    {
        private readonly IObserver<LogMessage> logger;
        private readonly INavigationService navigation;
        private readonly IUzivatelConnector uzivatelConnector;
        private readonly MainWindowViewModel mainWindow;

        public ReactiveProperty<string> Login { get; }
        public ReactiveProperty<string> Password { get; }
        public ReactiveCommand LogInCommand { get; }

        public LoginViewModel(IObserver<LogMessage> logger, INavigationService navigation, IUzivatelConnector uzivatelConnector, MainWindowViewModel mainWindow)
        {
            this.logger = logger;
            this.navigation = navigation;
            this.uzivatelConnector = uzivatelConnector;
            this.mainWindow = mainWindow;
            Login = new ReactiveProperty<string>();
            Password = new ReactiveProperty<string>();
            LogInCommand = ReactiveCommandHelper.Create(LoginAction);
        }

        private async void LoginAction()
        {
            try
            {
                var user = await uzivatelConnector.Login(new LoginModel { Login = Login.Value, Password = Password.Value });
                if (user != null)
                {
                    mainWindow.CurrentData.Uzivatel.Value = user;
                    navigation.Navigate(new HomeView());
                }
                else
                {
                    logger.OnNext(LogMessage.Error("Wrong credentials"));
                }
            }
            catch (Exception e)
            {
                logger.OnNext(LogMessage.Error(e.Message));
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
