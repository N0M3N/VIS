using Desktop.Attributes;
using Desktop.Connector;
using Desktop.Utils;
using Desktop.Services;
using Models;
using Reactive.Bindings;
using System;
using System.Windows.Controls;

namespace Desktop.Pages.ListZakazek
{
    [ViewModel]
    internal class ListZakazekViewModel : IDisposable
    {
        private readonly INavigationService navigation;
        private readonly IZakazkyConnector zakazkyConnector;
        private readonly MainWindowViewModel mainWindow;

        public ReactiveProperty<bool> CanExecute { get; }
        public ReactiveCollection<ZakazkaModel> Zakazky { get; }
        public ReactiveProperty<ZakazkaModel> Selected { get; }
        public ReactiveCommand<ZakazkaModel> ContinueCommand { get; }

        public ListZakazekViewModel(INavigationService navigation, IZakazkyConnector zakazkyConnector, MainWindowViewModel mainWindow)
        {
            Zakazky = new ReactiveCollection<ZakazkaModel>();
            CanExecute = new ReactiveProperty<bool>();
            Selected = new ReactiveProperty<ZakazkaModel>();
            Selected.PropertyChanged += (sender, args) => CanExecute.Value = Selected.Value != null;
            ContinueCommand = ReactiveCommandHelper.Create<ZakazkaModel>(Navigate);

            this.navigation = navigation;
            this.zakazkyConnector = zakazkyConnector;
            this.mainWindow = mainWindow;

            Populate();
        }

        private async void Populate()
        {
            Zakazky.AddRangeOnScheduler(await zakazkyConnector.GetAllByUserAsync(mainWindow.CurrentData.Uzivatel.Value));
        }

        private void Navigate(ZakazkaModel zakazka)
        {
            mainWindow.CurrentData.Zakazka = zakazka;
            navigation.Navigate((Page) Activator.CreateInstance(mainWindow.CurrentData.PageType));
        }

        public void Dispose()
        {
            Zakazky.Dispose();
            Selected.Dispose();
            ContinueCommand.Dispose();
            CanExecute.Dispose();
        }
    }
}
