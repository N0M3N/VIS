using Desktop.Attributes;
using Desktop.Connector;
using Desktop.Utils;
using Models;
using Reactive.Bindings;
using System;

namespace Desktop.Pages.DetailZakazky
{
    [ViewModel]
    internal class DetailZakazkyViewModel : IDisposable
    {
        private readonly IObserver<LogMessage> logger;
        private readonly IStavebniDenikConnector denikConnector;

        public ReactiveProperty<ZakazkaModel> VybranaZakazka { get; }
        public ReactiveCollection<StavebniDenikModel> Denik { get; }

        public DetailZakazkyViewModel(IObserver<LogMessage> logger, CurrentDataSingleton message, IStavebniDenikConnector denikConnector)
        {
            this.logger = logger;
            this.denikConnector = denikConnector;

            VybranaZakazka = new ReactiveProperty<ZakazkaModel>(message.Zakazka);
            Denik = new ReactiveCollection<StavebniDenikModel>();

            Populate();
        }

        private async void Populate()
        {
            try
            {
                var zaznamy = await denikConnector.GetByZakazka(VybranaZakazka.Value);
                foreach (var zaznam in zaznamy)
                {
                    Denik.AddOnScheduler(zaznam);
                }
            }
            catch(Exception e)
            {
                logger.OnNext(LogMessage.Error(e.Message));
            }
        }

        public void Dispose()
        {
            VybranaZakazka.Dispose();
            Denik.Dispose();
        }
    }
}
