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
                new ZakazkaModel { Id = 1, Name = "Dummy 1", Adresa = "Adress1" },
                new ZakazkaModel { Id = 2, Name = "Dummy 2", Adresa = "Adress2" }
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
