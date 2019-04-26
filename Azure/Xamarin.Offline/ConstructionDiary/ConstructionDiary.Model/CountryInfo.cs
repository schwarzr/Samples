using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConstructionDiary.Model
{
    [DataContract]
    public class CountryInfo
    {
        [DataMember]
        public string DisplayString { get; set; }

        [DataMember]
        public Guid Id { get; set; }
    }
}