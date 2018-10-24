using System;

namespace Models
{
    public class Zakazka
    {
        public int Id { get; set; }
        public Uzivatel Zakaznik { get; set; }
        public Uzivatel ZodpovednyZamestnanec { get; set; }
        public Stav Stav { get; set; }
        public string Adresa { get; set; }
        public DateTime Deadline { get; set; }
    }
}
