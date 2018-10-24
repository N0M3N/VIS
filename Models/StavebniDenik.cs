using System;

namespace Models
{
    public class StavebniDenik
    {
        public int Id { get; set; }
        public Zakazka Zakazka { get; set; }
        public Uzivatel Zamestnanec { get; set; }
        public DateTime Datum { get; set; }
        public string Popis { get; set; }
    }
}
