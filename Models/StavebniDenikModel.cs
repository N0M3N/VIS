using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    [KnownType(typeof(BaseModel))]
    [KnownType(typeof(ZakazkaModel))]
    [KnownType(typeof(UzivatelModel))]
    [KnownType(typeof(DateTime))]
    public class StavebniDenikModel : BaseModel
    {
        [DataMember]
        public ZakazkaModel Zakazka { get; set; }

        [DataMember]
        public UzivatelModel Zamestnanec { get; set; }

        [DataMember]
        public string Datum { get; set; }

        [DataMember]
        public string Popis { get; set; }
    }
}
