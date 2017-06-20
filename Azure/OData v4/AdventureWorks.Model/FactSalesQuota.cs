namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FactSalesQuota")]
    public partial class FactSalesQuota
    {
        [Key]
        public int SalesQuotaKey { get; set; }

        public int EmployeeKey { get; set; }

        public int DateKey { get; set; }

        public short CalendarYear { get; set; }

        public byte CalendarQuarter { get; set; }

        [Column(TypeName = "money")]
        public decimal SalesAmountQuota { get; set; }

        public DateTime? Date { get; set; }

        public virtual DimDate DimDate { get; set; }

        public virtual DimEmployee DimEmployee { get; set; }
    }
}
