using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    [KnownType(typeof(BaseModel))]
    [KnownType(typeof(UzivatelModel))]
    [KnownType(typeof(ZakazkaModel))]
    [KnownType(typeof(DateTime))]
    [KnownType(typeof(TimeSpan))]
    public class DochazkaModel : BaseModel
    {
        [DataMember]
        public ZakazkaModel Zakazka { get; set; }

        [DataMember]
        public UzivatelModel Zamestnanec { get; set; }

        [DataMember]
        public DateTime Datum { get; set; }

        [DataMember]
        public TimeSpan Prichod { get; set; }

        [DataMember]
        public TimeSpan Odchod { get; set; }
    }
}