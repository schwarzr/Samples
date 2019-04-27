using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionDiary.Model
{
    public class IssueCreateItem
    {
        public Guid AreaId { get; set; }

        public Guid? AssignedToId { get; set; }

        public IEnumerable<byte[]> Attachments { get; set; }

        public DateTime CreationTime { get; set; }

        public string Descripton { get; set; }

        public Guid IssueTypeId { get; set; }

        public string Title { get; set; }
    }
}