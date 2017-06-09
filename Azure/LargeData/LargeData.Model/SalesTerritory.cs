namespace LargeData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("DimSalesTerritory")]
    [DataContract(IsReference = true)]
    public partial class SalesTerritory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesTerritory()
        {
            Geographies = new HashSet<Geography>();
            InternetSales = new HashSet<InternetSale>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember(Order = 1)]
        virtual public ICollection<Geography> Geographies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember(Order = 2)]
        virtual public ICollection<InternetSale> InternetSales { get; set; }

        [DataMember(Order = 3)]
        public int? SalesTerritoryAlternateKey { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember(Order = 4)]
        public string SalesTerritoryCountry { get; set; }

        [StringLength(50)]
        [DataMember(Order = 5)]
        public string SalesTerritoryGroup { get; set; }

        [DataMember(Order = 6)]
        public byte[] SalesTerritoryImage { get; set; }

        [Key]
        [DataMember(Order = 7)]
        public int SalesTerritoryKey { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember(Order = 8)]
        public string SalesTerritoryRegion { get; set; }
    }
}