using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    [KnownType(typeof(BaseModel))]
    [KnownType(typeof(UzivatelModel))]
    [KnownType(typeof(StavModel))]
    [KnownType(typeof(DateTime))]
    public class ZakazkaModel : BaseModel
    {
        [DataMember]
        public string Nazev { get; set; }

        [DataMember]
        public UzivatelModel Zakaznik { get; set; }

        [DataMember]
        public UzivatelModel ZodpovednyZamestnanec { get; set; }

        [DataMember]
        public string Stav { get; set; }

        [DataMember]
        public string Adresa { get; set; }

        [DataMember]
        public string Deadline {
            get => deadline.ToShortDateString();
            set => deadline = Convert.ToDateTime(value);
        }

        private DateTime deadline;

    }
}
