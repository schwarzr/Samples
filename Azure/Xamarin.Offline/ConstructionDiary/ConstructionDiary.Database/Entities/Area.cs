using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConstructionDiary.Database.Entities
{
    public class Area
    {
        [StringLength(200)]
        [Required]
        public string AreaName { get; set; }

        public Guid Id { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}