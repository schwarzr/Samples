namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimReseller")]
    public partial class DimReseller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimReseller()
        {
            FactResellerSales = new HashSet<FactResellerSale>();
        }

        [Key]
        public int ResellerKey { get; set; }

        public int? GeographyKey { get; set; }

        [StringLength(15)]
        public string ResellerAlternateKey { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [Required]
        [StringLength(20)]
        public string BusinessType { get; set; }

        [Required]
        [StringLength(50)]
        public string ResellerName { get; set; }

        public int? NumberEmployees { get; set; }

        [StringLength(1)]
        public string OrderFrequency { get; set; }

        public byte? OrderMonth { get; set; }

        public int? FirstOrderYear { get; set; }

        public int? LastOrderYear { get; set; }

        [StringLength(50)]
        public string ProductLine { get; set; }

        [StringLength(60)]
        public string AddressLine1 { get; set; }

        [StringLength(60)]
        public string AddressLine2 { get; set; }

        [Column(TypeName = "money")]
        public decimal? AnnualSales { get; set; }

        [StringLength(50)]
        public string BankName { get; set; }

        public byte? MinPaymentType { get; set; }

        [Column(TypeName = "money")]
        public decimal? MinPaymentAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? AnnualRevenue { get; set; }

        public int? YearOpened { get; set; }

        public virtual DimGeography DimGeography { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactResellerSale> FactResellerSales { get; set; }
    }
}
