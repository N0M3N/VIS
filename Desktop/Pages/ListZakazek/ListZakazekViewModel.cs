using Desktop.Attributes;
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
        private readonly NavigateWithZakazkaMessage message;

        public ReactiveProperty<bool> CanExecute { get; }
        public ReactiveCollection<ZakazkaModel> Zakazky { get; }
        public ReactiveProperty<ZakazkaModel> Selected { get; }
        public ReactiveCommand<ZakazkaModel> ContinueCommand { get; }

        public ListZakazekViewModel(INavigationService navigation, NavigateWithZakazkaMessage message)
        {
            Zakazky = new ReactiveCollection<ZakazkaModel>();
            // TODO: Replace with remote connector
            Zakazky.AddRangeOnScheduler(new[]
            {
                new ZakazkaModel { Id = 1,
                    Name = "Dummy 1",
                    Zakaznik =new UzivatelModel { JeZakaznik = true, JeZamestnanec = false, Jmeno = "Pavel", Prijmeni = "Cucak" },
                    ZodpovednyZamestnanec = new UzivatelModel{ JeZakaznik = false, JeZamestnanec = true, Jmeno = "Zdenek", Prijmeni = "Steindl" },
                    Stav = new StavModel{ Id = 0, Nazev = "Nova" },
                    Deadline = DateTime.Now, Adresa = "Adress1" },
                new ZakazkaModel { Id = 2,
                    Name = "Dummy 2",
                    Zakaznik =new UzivatelModel { JeZakaznik = true, JeZamestnanec = false, Jmeno = "Pavel", Prijmeni = "Cucak" },
                    ZodpovednyZamestnanec = new UzivatelModel{ JeZakaznik = false, JeZamestnanec = true, Jmeno = "Zdenek", Prijmeni = "Steindl" },
                    Stav = new StavModel{ Id = 0, Nazev = "Dokoncena" },
                    Deadline = DateTime.Now, Adresa = "Adress2" },
            });

            CanExecute = new ReactiveProperty<bool>();
            Selected = new ReactiveProperty<ZakazkaModel>();
            Selected.PropertyChanged += (sender, args) => CanExecute.Value = Selected.Value != null;
            ContinueCommand = ReactiveCommandHelper.Create<ZakazkaModel>(Navigate);

            this.navigation = navigation;
            this.message = message;
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
