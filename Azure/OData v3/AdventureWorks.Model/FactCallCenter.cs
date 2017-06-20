namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FactCallCenter")]
    public partial class FactCallCenter
    {
        public int FactCallCenterID { get; set; }

        public int DateKey { get; set; }

        [Required]
        [StringLength(15)]
        public string WageType { get; set; }

        [Required]
        [StringLength(20)]
        public string Shift { get; set; }

        public short LevelOneOperators { get; set; }

        public short LevelTwoOperators { get; set; }

        public short TotalOperators { get; set; }

        public int Calls { get; set; }

        public int AutomaticResponses { get; set; }

        public int Orders { get; set; }

        public short IssuesRaised { get; set; }

        public short AverageTimePerIssue { get; set; }

        public double ServiceGrade { get; set; }

        public DateTime? Date { get; set; }

        public virtual DimDate DimDate { get; set; }
    }
}
