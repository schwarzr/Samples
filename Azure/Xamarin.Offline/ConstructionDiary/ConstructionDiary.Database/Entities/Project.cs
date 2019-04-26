using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionDiary.Database.Entities
{
    public class Project
    {
        public Project()
        {
            this.Areas = new HashSet<Area>();
            this.Employees = new HashSet<Employee>();
        }

        public ICollection<Area> Areas { get; set; }

        public Country Country { get; set; }

        public Guid CountryId { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Guid Id { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string ProjectName { get; set; }
    }
}