namespace Models
{

    public class Mzda
    {
        public int Id { get; set; }
        public Uzivatel Zamestnanec { get; set; }
        public Zakazka Zakazka { get; set; }
        public int Sazba { get; set; }
    }
}
