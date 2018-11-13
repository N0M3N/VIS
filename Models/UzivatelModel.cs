using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    [KnownType(typeof(BaseModel))]
    public class UzivatelModel : BaseModel
    {
        [DataMember]
        public string Jmeno { get; set; }

        [DataMember]
        public string Prijmeni { get; set; }

        [DataMember]
        public string Telefon { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public bool JeZakaznik { get; set; }

        [DataMember]
        public bool JeZamestnanec { get; set; }
    }
}
