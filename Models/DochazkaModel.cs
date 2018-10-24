using System;

namespace Models
{
    public class DochazkaModel : BaseModel
    {
        public ZakazkaModel Zakazka { get; set; }
        public UzivatelModel Zamestnanec { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan Prichod { get; set; }
        public TimeSpan Odchod { get; set; }
    }
}