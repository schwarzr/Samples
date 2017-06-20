namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FactCurrencyRate")]
    public partial class FactCurrencyRate
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CurrencyKey { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DateKey { get; set; }

        public double AverageRate { get; set; }

        public double EndOfDayRate { get; set; }

        public DateTime? Date { get; set; }

        public virtual DimCurrency DimCurrency { get; set; }

        public virtual DimDate DimDate { get; set; }
    }
}
