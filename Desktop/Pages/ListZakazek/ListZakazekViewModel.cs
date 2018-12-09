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
        private readonly CurrentDataSingleton currentData;

        public ReactiveProperty<bool> CanExecute { get; }

        public ReactiveCollection<ZakazkaModel> Zakazky { get; }
        public ReactiveProperty<ZakazkaModel> Selected { get; }
        public ReactiveCommand<ZakazkaModel> ContinueCommand { get; }

        public ListZakazekViewModel(INavigationService navigation, IZakazkyConnector zakazkyConnector, CurrentDataSingleton currentData)
        {
            Zakazky = new ReactiveCollection<ZakazkaModel>();
            CanExecute = new ReactiveProperty<bool>();
            Selected = new ReactiveProperty<ZakazkaModel>();
            Selected.PropertyChanged += (sender, args) => CanExecute.Value = Selected.Value != null;
            ContinueCommand = ReactiveCommandHelper.Create<ZakazkaModel>(Navigate);

            this.navigation = navigation;
            this.zakazkyConnector = zakazkyConnector;
            this.currentData = currentData;

            Populate();
        }

        private async void Populate()
        {
            Zakazky.AddRangeOnScheduler(await zakazkyConnector.GetAllByUserAsync(currentData.Uzivatel.Value));
        }

        private void Navigate(ZakazkaModel zakazka)
        {
            currentData.Zakazka = zakazka;
            navigation.Navigate((Page) Activator.CreateInstance(currentData.PageType));
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
