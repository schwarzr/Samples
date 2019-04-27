using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConstructionDiary.Database.Entities
{
    [DataContract]
    public class Employee
    {
        [DataMember(Order = 1)]
        public DateTime Created { get; set; }

        [DataMember(Order = 2)]
        [StringLength(200)]
        public string FirstName { get; set; }

        [DataMember(Order = 3)]
        public Guid Id { get; set; }

        [DataMember(Order = 4)]
        public bool IsDisabled { get; set; }

        [DataMember(Order = 5)]
        [StringLength(200)]
        [Required]
        public string LastName { get; set; }

        [DataMember(Order = 6)]
        public Project Project { get; set; }

        [DataMember(Order = 7)]
        public Guid ProjectId { get; set; }
    }
}