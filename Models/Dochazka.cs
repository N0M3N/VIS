using System;

namespace Models
{
    public class Dochazka
    {
        public int Id { get; set; }
        public Zakazka Zakazka { get; set; }
        public Uzivatel Zamestnanec { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan Prichod { get; set; }
        public TimeSpan Odchod { get; set; }
    }
}