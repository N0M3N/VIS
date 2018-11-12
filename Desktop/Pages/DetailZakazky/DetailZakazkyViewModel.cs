using Desktop.Attributes;
using Models;
using Reactive.Bindings;
using System;

namespace Desktop.Pages.DetailZakazky
{
    [ViewModel]
    public class DetailZakazkyViewModel : IDisposable
    {
        public ReactiveProperty<ZakazkaModel> VybranaZakazka { get; }

        public DetailZakazkyViewModel()
        {
            VybranaZakazka = new ReactiveProperty<ZakazkaModel>();
        }
        
        public void Dispose()
        {
            VybranaZakazka.Dispose();
        }
    }
}
