using System;
using System.Runtime.Serialization;

namespace ConstructionDiary.Model
{
    public class EmployeeListItem
    {
        public DateTime Created { get; set; }

        public string FirstName { get; set; }

        public Guid Id { get; set; }

        public bool IsDisabled { get; set; }

        public string LastName { get; set; }
    }
}