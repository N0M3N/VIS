using Desktop.Attributes;
using Desktop.Connector;
using Models;
using Reactive.Bindings;
using System;

namespace Desktop.Pages.DetailZakazky
{
    [ViewModel]
    internal class DetailZakazkyViewModel : IDisposable
    {
        private readonly IStavebniDenikConnector denikConnector;

        public ReactiveProperty<ZakazkaModel> VybranaZakazka { get; }
        public ReactiveCollection<StavebniDenikModel> Denik { get; }

        public DetailZakazkyViewModel(CurrentDataSingleton message, IStavebniDenikConnector denikConnector)
        {
            this.denikConnector = denikConnector;

            VybranaZakazka = new ReactiveProperty<ZakazkaModel>(message.Zakazka);
            Denik = new ReactiveCollection<StavebniDenikModel>();

            Populate();
        }

        private async void Populate()
        {
            var zaznamy = await denikConnector.GetByZakazka(VybranaZakazka.Value);
            foreach(var zaznam in zaznamy)
            {
                Denik.AddOnScheduler(zaznam);
            }
        }

        public void Dispose()
        {
            VybranaZakazka.Dispose();
            Denik.Dispose();
        }
    }
}
