using System;
using System.ComponentModel.DataAnnotations;

namespace ConstructionDiary.Database.Entities
{
    public class Country
    {
        public Guid Id { get; set; }

        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        [StringLength(2)]
        [Required]
        public string TwoLetterIso { get; set; }
    }
}