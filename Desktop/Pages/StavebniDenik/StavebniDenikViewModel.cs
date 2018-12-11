using Desktop.Attributes;
using Desktop.Connector;
using Desktop.Utils;
using Models;
using Reactive.Bindings;
using System;

namespace Desktop.Pages.StavebniDenik
{
    [ViewModel]
    internal class StavebniDenikViewModel : IDisposable
    {
        private readonly IObserver<LogMessage> logger;
        private readonly CurrentDataSingleton currentData;
        private readonly IStavebniDenikConnector denikConnector;

        public ReactiveProperty<string> Popis { get; }
        public ReactiveProperty<DateTime> Datum { get; }

        public ReactiveCollection<StavebniDenikModel> Denik { get; }
        public ReactiveCommand PridatZaznamCommand { get; }

        public StavebniDenikViewModel(IObserver<LogMessage> logger, CurrentDataSingleton currentData, IStavebniDenikConnector denikConnector)
        {
            this.logger = logger;
            this.currentData = currentData;
            this.denikConnector = denikConnector;

            Popis = new ReactiveProperty<string>();
            Datum = new ReactiveProperty<DateTime>(DateTime.Now);
            Denik = new ReactiveCollection<StavebniDenikModel>();

            PridatZaznamCommand = ReactiveCommandHelper.Create(PridatZaznamAction);

            Populate();
        }

        private async void PridatZaznamAction()
        { 
            try
            {
                var result = await denikConnector.Add(
                    new StavebniDenikModel {
                        Datum = Datum.Value.ToShortDateString(),
                        Popis = Popis.Value,
                        Zakazka = currentData.Zakazka,
                        Zamestnanec = currentData.Uzivatel.Value });

                logger.OnNext(LogMessage.Success("Zaznam pridan"));

                Denik.AddOnScheduler(result);
            }
            catch (Exception e)
            {
                logger.OnNext(LogMessage.Error(e.Message));
            }
        }

        private async void Populate()
        {
            try
            {
                var zaznamy = await denikConnector.GetByZakazka(currentData.Zakazka);
                foreach (var zaznam in zaznamy)
                {
                    Denik.AddOnScheduler(zaznam);
                }
            }
            catch (Exception e)
            {
                logger.OnNext(LogMessage.Error(e.Message));
            }
        }

        public void Dispose()
        {
            Denik.Dispose();
            Popis.Dispose();
            Datum.Dispose();

            PridatZaznamCommand.Dispose();
        }
    }
}
