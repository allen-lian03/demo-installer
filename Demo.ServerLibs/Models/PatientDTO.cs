using System;
using System.Runtime.Serialization;

namespace Demo.ServerLibs.Models
{
    [DataContract]
    public class PatientDTO
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }

        [DataMember]
        public int Age
        {
            get { return DateTime.Today.Year - Birthday.Year; }
            set { }
        }

        [DataMember]
        public string CardNo { get; set; }

        [DataMember]
        public string IC { get; set; }
    }
}