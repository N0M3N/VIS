using Desktop.Attributes;
using Desktop.Connector;
using Desktop.Services;
using Desktop.Utils;
using Microsoft.Win32;
using Models;
using Models.API_Models;
using Reactive.Bindings;
using System;
using System.Diagnostics;

namespace Desktop.Pages.Kalkulace
{
    [ViewModel]
    internal class KalkulaceViewModel : IDisposable
    {
        private readonly CurrentDataSingleton currentData;
        private readonly IFileExportService exportService;
        private readonly IKalkulaceConnector kalkulaceConnector;

        public ReactiveCommand ExportToXmlCommand { get; }
        public ReactiveProperty<KalkulaceGetModel> Kalkulace { get; }
        public ReactiveProperty<ZakazkaModel> Zakazka { get; }

        public KalkulaceViewModel(CurrentDataSingleton currentData, IFileExportService exportService, IKalkulaceConnector kalkulaceConnector)
        {
            ExportToXmlCommand = ReactiveCommandHelper.Create(ExportToXmlAction);
            Kalkulace = new ReactiveProperty<KalkulaceGetModel>();
            Zakazka = new ReactiveProperty<ZakazkaModel>();
            this.currentData = currentData;
            this.exportService = exportService;
            this.kalkulaceConnector = kalkulaceConnector;

            Populate();
        }

        private async void Populate()
        {
            Zakazka.Value = currentData.Zakazka;

            var kalkulace = await kalkulaceConnector.GetByZakazka(currentData.Zakazka);
            if(kalkulace != null)
            {
                Kalkulace.Value = kalkulace;
            }
        }

        private async void ExportToXmlAction()
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Xml file (*.xml)|*.xml";
            if (dialog.ShowDialog() == true)
            {
                var path = dialog.FileName;
                var result = await exportService.Export(path, Kalkulace.Value);
                if (result)
                {
                    Process.Start(path);
                }
            }
        }

        public void Dispose()
        {
            ExportToXmlCommand.Dispose();
            Zakazka.Dispose();
            Kalkulace.Dispose();
        }
    }
}
