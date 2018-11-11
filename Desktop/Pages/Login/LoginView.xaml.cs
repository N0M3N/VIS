using System.Windows;
using System.Windows.Controls;

namespace Desktop.Pages.Login
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var dataContext = (LoginViewModel)DataContext;
            dataContext.Password.Value = ((PasswordBox)sender).Password;
        }
    }
}
