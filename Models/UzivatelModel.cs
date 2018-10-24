namespace Models
{
    public class UzivatelModel : BaseModel
    {
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Telefon { get; set; }
        public string Login { get; set; }
        public bool JeZakaznik { get; set; }
        public bool JeZamestananec { get; set; }
    }
}
