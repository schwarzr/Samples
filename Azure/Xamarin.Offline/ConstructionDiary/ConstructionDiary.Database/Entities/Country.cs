using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConstructionDiary.Database.Entities
{
    [DataContract]
    public class Country
    {
        [DataMember(Order = 1)]
        public Guid Id { get; set; }

        [StringLength(200)]
        [Required]
        [DataMember(Order = 2)]
        public string Name { get; set; }

        [StringLength(2)]
        [Required]
        [DataMember(Order = 3)]
        public string TwoLetterIso { get; set; }
    }
}