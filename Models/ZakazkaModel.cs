using System;

namespace Models
{
    public class ZakazkaModel : BaseModel
    {
        public string Name { get; set; }
        public UzivatelModel Zakaznik { get; set; }
        public UzivatelModel ZodpovednyZamestnanec { get; set; }
        public StavModel Stav { get; set; }
        public string Adresa { get; set; }
        public DateTime Deadline { get; set; }
    }
}
