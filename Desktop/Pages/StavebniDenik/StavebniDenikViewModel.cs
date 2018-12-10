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
        private readonly CurrentDataSingleton currentData;
        private readonly IStavebniDenikConnector denikConnector;

        public ReactiveProperty<string> Popis { get; }
        public ReactiveProperty<DateTime> Datum { get; }

        public ReactiveCollection<StavebniDenikModel> Denik { get; }
        public ReactiveCommand PridatZaznamCommand { get; }

        public StavebniDenikViewModel(CurrentDataSingleton currentData, IStavebniDenikConnector denikConnector)
        {
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
                Denik.AddOnScheduler(result);
            }
            catch (Exception e)
            {

            }
        }

        private async void Populate()
        {
            var zaznamy = await denikConnector.GetByZakazka(currentData.Zakazka);
            foreach (var zaznam in zaznamy)
            {
                Denik.AddOnScheduler(zaznam);
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
