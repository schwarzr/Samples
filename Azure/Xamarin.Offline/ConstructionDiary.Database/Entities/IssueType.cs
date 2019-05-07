using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace ConstructionDiary.Database.Entities
{
    [DataContract]
    public class IssueType
    {
        [DataMember(Order = 1)]
        [StringLength(2000)]
        public string Description { get; set; }

        [DataMember(Order = 2)]
        public Guid Id { get; set; }

        [DataMember(Order = 3)]
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}