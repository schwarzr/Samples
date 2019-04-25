using System;
using System.ComponentModel.DataAnnotations;

namespace ConstructionDiary.Database.Entities
{
    public class User
    {
        public DateTime Created { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        public Guid Id { get; set; }

        public bool IsDisabled { get; set; }

        [StringLength(200)]
        public string LastName { get; set; }

        [Required]
        [StringLength(200)]
        public string Login { get; set; }
    }
}