using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConstructionDiary.Model
{
    [DataContract]
    public class CountryListItem
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string IsoTwo { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}