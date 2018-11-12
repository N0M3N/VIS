using CommonServiceLocator;
using Desktop.Attributes;
using Desktop.Connector;
using Desktop.Extensions;
using Desktop.Messages;
using Desktop.Services;
using Models;
using Reactive.Bindings;
using System;
using System.Reactive.Subjects;
using System.Windows.Controls;

namespace Desktop.Pages.ListZakazek
{
    [ViewModel]
    internal class ListZakazekViewModel : IDisposable
    {
        private readonly INavigationService navigation;
        private readonly IZakazkyConnector zakazkyConnector;
        private readonly NavigateWithZakazkaMessage message;

        public ReactiveProperty<bool> CanExecute { get; }
        public ReactiveCollection<ZakazkaModel> Zakazky { get; }
        public ReactiveProperty<ZakazkaModel> Selected { get; }
        public ReactiveCommand<ZakazkaModel> ContinueCommand { get; }

        public ListZakazekViewModel(INavigationService navigation, IZakazkyConnector zakazkyConnector, NavigateWithZakazkaMessage message)
        {
            Zakazky = new ReactiveCollection<ZakazkaModel>();
            CanExecute = new ReactiveProperty<bool>();
            Selected = new ReactiveProperty<ZakazkaModel>();
            Selected.PropertyChanged += (sender, args) => CanExecute.Value = Selected.Value != null;
            ContinueCommand = ReactiveCommandHelper.Create<ZakazkaModel>(Navigate);

            this.navigation = navigation;
            this.zakazkyConnector = zakazkyConnector;
            this.message = message;

            Populate();
        }

        private async void Populate()
        {
            Zakazky.AddRangeOnScheduler(await zakazkyConnector.GetAllByUserAsync(ServiceLocator.Current.GetInstance<MainWindowViewModel>().CurrentUser.Value));
        }

        private void Navigate(ZakazkaModel obj)
        {
            message.Zakazka = obj;
            navigation.Navigate((Page) Activator.CreateInstance(message.PageType));
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
