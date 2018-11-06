using Desktop.Pages;
using Desktop.Services;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Reactive.Linq;

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

            ServiceLocator.Instance
                .GetService<IObservable<Page>>()
                .Subscribe(page =>
                {
                    var previous = Frame.Content as Page;

                    Frame.Navigate(page);

                    var datacontext = previous?.DataContext as IDisposable;
                    datacontext?.Dispose();
                });

            ServiceLocator.Instance
                .GetService<INavigationService>()
                .Navigate(new Login());
        }
    }
}
