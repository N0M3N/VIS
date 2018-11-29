using System;

namespace Models
{
    public class DochazkaModel : BaseModel
    {
        public string Datum { get; set; }
        public TimeSpan Prichod { get; set; }
        public TimeSpan Odchod { get; set; }
        public UzivatelModel Zamestnanec { get; set; }
        public int Sazba { get; set; }
    }
}
