using Desktop.Attributes;
using Desktop.Controls;
using Models;
using Reactive.Bindings;
using System;

namespace Desktop.Pages.DetailZakazky
{
    [ViewModel]
    public class DetailZakazkyViewModel : IDisposable
    {
        public ReactiveProperty<ListZakazekViewModel> ListZakazek { get; }
        public ReactiveProperty<ZakazkaModel> VybranaZakazka { get; }

        public DetailZakazkyViewModel()
        {
            ListZakazek = new ReactiveProperty<ListZakazekViewModel>(new ListZakazekViewModel());
            VybranaZakazka = new ReactiveProperty<ZakazkaModel>();

            ListZakazek.Value.Selected.PropertyChanged += ZakazkaSelected;
        }

        private void ZakazkaSelected(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            VybranaZakazka.Value = ListZakazek.Value.Selected.Value;
        }

        public void Dispose()
        {
            ListZakazek.Dispose();
        }
    }
}
