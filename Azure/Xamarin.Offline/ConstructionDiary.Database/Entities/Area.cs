using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace ConstructionDiary.Database.Entities
{
    [DataContract]
    public class Area
    {
        [StringLength(200)]
        [Required]
        [DataMember(Order = 1)]
        public string AreaName { get; set; }

        [DataMember(Order = 2)]
        public Guid Id { get; set; }

        [DataMember(Order = 3)]
        public Project Project { get; set; }

        [DataMember(Order = 4)]
        public Guid ProjectId { get; set; }
    }
}