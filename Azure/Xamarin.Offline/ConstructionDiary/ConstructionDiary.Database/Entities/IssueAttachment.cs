using System;
using System.ComponentModel.DataAnnotations;

namespace ConstructionDiary.Database.Entities
{
    public class IssueAttachment
    {
        public byte[] Content { get; set; }

        public Guid Id { get; set; }

        public Issue Issue { get; set; }

        public Guid IssueId { get; set; }

        [MaxLength(40000)]
        public byte[] Thumbnail { get; set; }
    }
}