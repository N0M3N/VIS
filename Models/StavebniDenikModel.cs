using System;

namespace Models
{
    public class StavebniDenikModel : BaseModel
    {
        public ZakazkaModel Zakazka { get; set; }
        public UzivatelModel Zamestnanec { get; set; }
        public DateTime Datum { get; set; }
        public string Popis { get; set; }
    }
}
