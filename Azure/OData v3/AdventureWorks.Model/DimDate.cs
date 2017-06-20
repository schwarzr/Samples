namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimDate")]
    public partial class DimDate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimDate()
        {
            FactCallCenters = new HashSet<FactCallCenter>();
            FactCurrencyRates = new HashSet<FactCurrencyRate>();
            FactFinances = new HashSet<FactFinance>();
            FactInternetSales = new HashSet<FactInternetSale>();
            FactInternetSales1 = new HashSet<FactInternetSale>();
            FactInternetSales2 = new HashSet<FactInternetSale>();
            FactProductInventories = new HashSet<FactProductInventory>();
            FactResellerSales = new HashSet<FactResellerSale>();
            FactResellerSales1 = new HashSet<FactResellerSale>();
            FactResellerSales2 = new HashSet<FactResellerSale>();
            FactSalesQuotas = new HashSet<FactSalesQuota>();
            FactSurveyResponses = new HashSet<FactSurveyResponse>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DateKey { get; set; }

        [Column(TypeName = "date")]
        public DateTime FullDateAlternateKey { get; set; }

        public byte DayNumberOfWeek { get; set; }

        [Required]
        [StringLength(10)]
        public string EnglishDayNameOfWeek { get; set; }

        [Required]
        [StringLength(10)]
        public string SpanishDayNameOfWeek { get; set; }

        [Required]
        [StringLength(10)]
        public string FrenchDayNameOfWeek { get; set; }

        public byte DayNumberOfMonth { get; set; }

        public short DayNumberOfYear { get; set; }

        public byte WeekNumberOfYear { get; set; }

        [Required]
        [StringLength(10)]
        public string EnglishMonthName { get; set; }

        [Required]
        [StringLength(10)]
        public string SpanishMonthName { get; set; }

        [Required]
        [StringLength(10)]
        public string FrenchMonthName { get; set; }

        public byte MonthNumberOfYear { get; set; }

        public byte CalendarQuarter { get; set; }

        public short CalendarYear { get; set; }

        public byte CalendarSemester { get; set; }

        public byte FiscalQuarter { get; set; }

        public short FiscalYear { get; set; }

        public byte FiscalSemester { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactCallCenter> FactCallCenters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactCurrencyRate> FactCurrencyRates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactFinance> FactFinances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactInternetSale> FactInternetSales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactInternetSale> FactInternetSales1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactInternetSale> FactInternetSales2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactProductInventory> FactProductInventories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactResellerSale> FactResellerSales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactResellerSale> FactResellerSales1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactResellerSale> FactResellerSales2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactSalesQuota> FactSalesQuotas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactSurveyResponse> FactSurveyResponses { get; set; }
    }
}
