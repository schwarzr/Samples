using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConstructionDiary.Database.Entities
{
    [DataContract]
    public class Issue
    {
        public Issue()
        {
            this.Attachments = new HashSet<IssueAttachment>();
        }

        [DataMember(Order = 1)]
        public Area Area { get; set; }

        [DataMember(Order = 2)]
        public Guid AreaId { get; set; }

        [DataMember(Order = 3)]
        public Employee AssignedTo { get; set; }

        [DataMember(Order = 4)]
        public Guid? AssignedToId { get; set; }

        [DataMember(Order = 5)]
        public ICollection<IssueAttachment> Attachments { get; set; }

        [DataMember(Order = 6)]
        public DateTime CreationTime { get; set; }

        [DataMember(Order = 7)]
        public Guid Id { get; set; }

        [StringLength(2000)]
        [DataMember(Order = 8)]
        public string IssueDescripton { get; set; }

        [DataMember(Order = 9)]
        public IssueType IssueType { get; set; }

        [DataMember(Order = 10)]
        public Guid IssueTypeId { get; set; }

        [StringLength(200)]
        [Required]
        [DataMember(Order = 11)]
        public string Title { get; set; }
    }
}