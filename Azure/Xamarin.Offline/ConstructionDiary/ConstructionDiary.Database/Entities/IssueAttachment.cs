using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConstructionDiary.Database.Entities
{
    [DataContract]
    public class IssueAttachment
    {
        [DataMember(Order = 1)]
        public byte[] Content { get; set; }

        [DataMember(Order = 2)]
        public Guid Id { get; set; }

        [DataMember(Order = 3)]
        public Issue Issue { get; set; }

        [DataMember(Order = 4)]
        public Guid IssueId { get; set; }

        [DataMember(Order = 5)]
        [MaxLength(40000)]
        public byte[] Thumbnail { get; set; }
    }
}