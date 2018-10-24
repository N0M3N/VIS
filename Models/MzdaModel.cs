namespace Models
{
    public class MzdaModel : BaseModel
    {
        public UzivatelModel Zamestnanec { get; set; }
        public ZakazkaModel Zakazka { get; set; }
        public int Sazba { get; set; }
    }
}
