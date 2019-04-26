using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConstructionDiary.Database.Entities
{
    public class Issue
    {
        public Area Area { get; set; }

        public Guid AreaId { get; set; }

        public Employee AssignedTo { get; set; }

        public Guid? AssignedToId { get; set; }

        public ICollection<IssueAttachment> Attachments { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid Id { get; set; }

        [StringLength(2000)]
        public string IssueDescripton { get; set; }

        [StringLength(200)]
        [Required]
        public string Title { get; set; }
    }
}