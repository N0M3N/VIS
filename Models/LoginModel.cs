using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class LoginModel
    {
        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}
