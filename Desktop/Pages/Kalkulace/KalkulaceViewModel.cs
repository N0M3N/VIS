using Desktop.Attributes;
using Desktop.Services;
using Desktop.Utils;
using Microsoft.Win32;
using Models.API_Models;
using Reactive.Bindings;
using System;
using System.Diagnostics;

namespace Desktop.Pages.Kalkulace
{
    [ViewModel]
    internal class KalkulaceViewModel : IDisposable
    {
        private readonly IFileExportService exportService;

        public ReactiveCommand ExportToXmlCommand { get; }
        public ReactiveProperty<KalkulaceGetModel> Kalkulace { get; }

        public KalkulaceViewModel(IFileExportService exportService)
        {
            ExportToXmlCommand = ReactiveCommandHelper.Create(ExportToXmlAction);
            Kalkulace = new ReactiveProperty<KalkulaceGetModel>(); // TODO: set value using KalkulaceConnector
            this.exportService = exportService;
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
            Kalkulace.Dispose();
        }
    }
}
