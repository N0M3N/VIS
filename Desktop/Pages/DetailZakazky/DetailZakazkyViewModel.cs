using Desktop.Attributes;
using Models;
using Reactive.Bindings;
using System;

namespace Desktop.Pages.DetailZakazky
{
    [ViewModel]
    internal class DetailZakazkyViewModel : IDisposable
    {
        public ReactiveProperty<ZakazkaModel> VybranaZakazka { get; }

        public DetailZakazkyViewModel(CurrentDataSingleton message)
        {
            VybranaZakazka = new ReactiveProperty<ZakazkaModel>(message.Zakazka);
        }
        
        public void Dispose()
        {
            VybranaZakazka.Dispose();
        }
    }
}
