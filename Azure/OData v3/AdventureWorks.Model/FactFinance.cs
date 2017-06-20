namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FactFinance")]
    public partial class FactFinance
    {
        [Key]
        [Column(Order = 0)]
        public int FinanceKey { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DateKey { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrganizationKey { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentGroupKey { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ScenarioKey { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountKey { get; set; }

        [Key]
        [Column(Order = 6)]
        public double Amount { get; set; }

        public DateTime? Date { get; set; }

        public virtual DimAccount DimAccount { get; set; }

        public virtual DimDate DimDate { get; set; }

        public virtual DimDepartmentGroup DimDepartmentGroup { get; set; }

        public virtual DimOrganization DimOrganization { get; set; }

        public virtual DimScenario DimScenario { get; set; }
    }
}
