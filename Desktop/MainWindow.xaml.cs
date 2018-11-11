using CommonServiceLocator;
using Desktop.Pages.Login;
using Desktop.Services;
using System;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Frame.JournalOwnership = JournalOwnership.OwnsJournal;

            ServiceLocator.Current
                .GetInstance<IObservable<Page>>()
                .Subscribe(page =>
                {
                    var previousPage = Frame.Content as Page;

                    Frame.Navigate(page);

                    var datacontext = previousPage?.DataContext as IDisposable;
                    datacontext?.Dispose();
                });

            ServiceLocator.Current
                .GetInstance<INavigationService>()
                .Navigate(new LoginView());
        }
    }
}
