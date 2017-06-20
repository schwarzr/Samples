namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimProduct")]
    public partial class DimProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimProduct()
        {
            FactInternetSales = new HashSet<FactInternetSale>();
            FactProductInventories = new HashSet<FactProductInventory>();
            FactResellerSales = new HashSet<FactResellerSale>();
        }

        [Key]
        public int ProductKey { get; set; }

        [StringLength(25)]
        public string ProductAlternateKey { get; set; }

        public int? ProductSubcategoryKey { get; set; }

        [StringLength(3)]
        public string WeightUnitMeasureCode { get; set; }

        [StringLength(3)]
        public string SizeUnitMeasureCode { get; set; }

        [Required]
        [StringLength(50)]
        public string EnglishProductName { get; set; }

        [Required]
        [StringLength(50)]
        public string SpanishProductName { get; set; }

        [Required]
        [StringLength(50)]
        public string FrenchProductName { get; set; }

        [Column(TypeName = "money")]
        public decimal? StandardCost { get; set; }

        public bool FinishedGoodsFlag { get; set; }

        [Required]
        [StringLength(15)]
        public string Color { get; set; }

        public short? SafetyStockLevel { get; set; }

        public short? ReorderPoint { get; set; }

        [Column(TypeName = "money")]
        public decimal? ListPrice { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(50)]
        public string SizeRange { get; set; }

        public double? Weight { get; set; }

        public int? DaysToManufacture { get; set; }

        [StringLength(2)]
        public string ProductLine { get; set; }

        [Column(TypeName = "money")]
        public decimal? DealerPrice { get; set; }

        [StringLength(2)]
        public string Class { get; set; }

        [StringLength(2)]
        public string Style { get; set; }

        [StringLength(50)]
        public string ModelName { get; set; }

        public byte[] LargePhoto { get; set; }

        [StringLength(400)]
        public string EnglishDescription { get; set; }

        [StringLength(400)]
        public string FrenchDescription { get; set; }

        [StringLength(400)]
        public string ChineseDescription { get; set; }

        [StringLength(400)]
        public string ArabicDescription { get; set; }

        [StringLength(400)]
        public string HebrewDescription { get; set; }

        [StringLength(400)]
        public string ThaiDescription { get; set; }

        [StringLength(400)]
        public string GermanDescription { get; set; }

        [StringLength(400)]
        public string JapaneseDescription { get; set; }

        [StringLength(400)]
        public string TurkishDescription { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(7)]
        public string Status { get; set; }

        public virtual DimProductSubcategory DimProductSubcategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactInternetSale> FactInternetSales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactProductInventory> FactProductInventories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactResellerSale> FactResellerSales { get; set; }
    }
}
