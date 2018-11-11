using Desktop.Attributes;
using Models;
using Reactive.Bindings;
using System;

namespace Desktop.Controls
{
    [ViewModel]
    public class ListZakazekViewModel : IDisposable
    {
        public ReactiveCollection<ZakazkaModel> Zakazky { get; }
        public ReactiveProperty<ZakazkaModel> Selected { get; }

        public ListZakazekViewModel()
        {
            Zakazky = new ReactiveCollection<ZakazkaModel>();
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
            //TODO: Zakazky.AddRangeOnScheduler(DB.GetAllByUser(CurrentUserId));

            Selected = new ReactiveProperty<ZakazkaModel>();
        }

        public void Dispose()
        {
            Zakazky.Dispose();
            Selected.Dispose();
        }
    }
}
