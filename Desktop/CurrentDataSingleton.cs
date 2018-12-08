using Models;
using Reactive.Bindings;
using System;

namespace Desktop
{
    internal class CurrentDataSingleton : IDisposable
    {
        internal Type PageType { get; set; } = null;
        internal ZakazkaModel Zakazka { get; set; } = null;

        public ReactiveProperty<UzivatelModel> Uzivatel { get; set; }

        public CurrentDataSingleton()
        {
            Uzivatel = new ReactiveProperty<UzivatelModel>();
        }

        public void Dispose()
        {
            Uzivatel.Dispose();
        }
    }
}