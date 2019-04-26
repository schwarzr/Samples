using System;
using System.ComponentModel.DataAnnotations;

namespace ConstructionDiary.Database.Entities
{
    public class Employee
    {
        public DateTime Created { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        public Guid Id { get; set; }

        public bool IsDisabled { get; set; }

        [StringLength(200)]
        [Required]
        public string LastName { get; set; }

        public Project Project { get; set; }

        public Guid ProjectId { get; set; }
    }
}