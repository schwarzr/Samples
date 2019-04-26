using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConstructionDiary.Database.Entities
{
    public class IssueType
    {
        [StringLength(2000)]
        public string Description { get; set; }

        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}