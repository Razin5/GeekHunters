using System.Runtime.Serialization;
namespace GeekRegistrationSystemCore
{
    [DataContract]
    public class CandidateDetails
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Technology { get; set; }
    }
}
