using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    [KnownType(typeof(BaseModel))]
    public class StavModel : BaseModel
    {
        [DataMember]
        public string Nazev { get; set; }
    }
}
