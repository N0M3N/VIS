using Desktop.Attributes;
using Desktop.Messages;
using Models;
using Reactive.Bindings;
using System;

namespace Desktop.Pages.DetailZakazky
{
    [ViewModel]
    internal class DetailZakazkyViewModel : IDisposable
    {
        public ReactiveProperty<ZakazkaModel> VybranaZakazka { get; }

        public DetailZakazkyViewModel(NavigateWithZakazkaMessage message)
        {
            VybranaZakazka = new ReactiveProperty<ZakazkaModel>(message.Zakazka);
        }


        
        public void Dispose()
        {
            VybranaZakazka.Dispose();
        }
    }
}
