namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimGeography")]
    public partial class DimGeography
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimGeography()
        {
            DimCustomers = new HashSet<DimCustomer>();
            DimResellers = new HashSet<DimReseller>();
        }

        [Key]
        public int GeographyKey { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(3)]
        public string StateProvinceCode { get; set; }

        [StringLength(50)]
        public string StateProvinceName { get; set; }

        [StringLength(3)]
        public string CountryRegionCode { get; set; }

        [StringLength(50)]
        public string EnglishCountryRegionName { get; set; }

        [StringLength(50)]
        public string SpanishCountryRegionName { get; set; }

        [StringLength(50)]
        public string FrenchCountryRegionName { get; set; }

        [StringLength(15)]
        public string PostalCode { get; set; }

        public int? SalesTerritoryKey { get; set; }

        [StringLength(15)]
        public string IpAddressLocator { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DimCustomer> DimCustomers { get; set; }

        public virtual DimSalesTerritory DimSalesTerritory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DimReseller> DimResellers { get; set; }
    }
}
