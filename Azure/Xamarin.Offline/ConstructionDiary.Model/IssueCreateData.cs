using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionDiary.Model
{
    public class IssueCreateData
    {
        public IEnumerable<EmployeeInfo> Employees { get; set; }

        public IEnumerable<IssueTypeInfo> IssueTypes { get; set; }
    }
}