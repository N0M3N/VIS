using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    [KnownType(typeof(BaseModel))]
    [KnownType(typeof(ZakazkaModel))]
    public class MzdaModel : BaseModel
    {
        [DataMember]
        public UzivatelModel Zamestnanec { get; set; }
        
        [DataMember]
        public ZakazkaModel Zakazka { get; set; }

        [DataMember]
        public int Sazba { get; set; }
    }
}
