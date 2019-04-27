using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConstructionDiary.Database.Entities
{
    [DataContract]
    public class Project
    {
        public Project()
        {
            this.Areas = new HashSet<Area>();
            this.Employees = new HashSet<Employee>();
        }

        [DataMember(Order = 1)]
        public ICollection<Area> Areas { get; set; }

        [DataMember(Order = 2)]
        public Country Country { get; set; }

        [DataMember(Order = 3)]
        public Guid CountryId { get; set; }

        [DataMember(Order = 4)]
        public ICollection<Employee> Employees { get; set; }

        [DataMember(Order = 5)]
        public Guid Id { get; set; }

        [DataMember(Order = 6)]
        public decimal Latitude { get; set; }

        [DataMember(Order = 7)]
        public decimal Longitude { get; set; }

        [DataMember(Order = 8)]
        public string ProjectName { get; set; }
    }
}