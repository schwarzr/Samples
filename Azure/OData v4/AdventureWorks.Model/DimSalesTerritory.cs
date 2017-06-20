namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimSalesTerritory")]
    public partial class DimSalesTerritory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimSalesTerritory()
        {
            DimEmployees = new HashSet<DimEmployee>();
            DimGeographies = new HashSet<DimGeography>();
            FactInternetSales = new HashSet<FactInternetSale>();
            FactResellerSales = new HashSet<FactResellerSale>();
        }

        [Key]
        public int SalesTerritoryKey { get; set; }

        public int? SalesTerritoryAlternateKey { get; set; }

        [Required]
        [StringLength(50)]
        public string SalesTerritoryRegion { get; set; }

        [Required]
        [StringLength(50)]
        public string SalesTerritoryCountry { get; set; }

        [StringLength(50)]
        public string SalesTerritoryGroup { get; set; }

        public byte[] SalesTerritoryImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DimEmployee> DimEmployees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DimGeography> DimGeographies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactInternetSale> FactInternetSales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactResellerSale> FactResellerSales { get; set; }
    }
}
