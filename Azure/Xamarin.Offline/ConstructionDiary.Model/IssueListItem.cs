using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionDiary.Model
{
    public class IssueListItem
    {
        public string AssignedTo { get; set; }

        public DateTime CreateTime { get; set; }

        public string Description { get; set; }

        public Guid Id { get; set; }

        public string IssueType { get; set; }

        public string Title { get; set; }
    }
}