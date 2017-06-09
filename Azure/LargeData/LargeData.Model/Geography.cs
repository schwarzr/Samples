namespace LargeData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("DimGeography")]
    [DataContract(IsReference = true)]
    public partial class Geography
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Geography()
        {
            Customers = new HashSet<Customer>();
        }

        [StringLength(30)]
        [DataMember(Order = 1)]
        public string City { get; set; }

        [StringLength(3)]
        [DataMember(Order = 2)]
        public string CountryRegionCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember(Order = 3)]
        virtual public ICollection<Customer> Customers { get; set; }

        [StringLength(50)]
        [DataMember(Order = 4)]
        public string EnglishCountryRegionName { get; set; }

        [StringLength(50)]
        [DataMember(Order = 5)]
        public string FrenchCountryRegionName { get; set; }

        [Key]
        [DataMember(Order = 6)]
        public int GeographyKey { get; set; }

        [StringLength(15)]
        [DataMember(Order = 7)]
        public string IpAddressLocator { get; set; }

        [StringLength(15)]
        [DataMember(Order = 8)]
        public string PostalCode { get; set; }

        [DataMember(Order = 9)]
        virtual public SalesTerritory SalesTerritory { get; set; }

        [DataMember(Order = 10)]
        public int? SalesTerritoryKey { get; set; }

        [StringLength(50)]
        [DataMember(Order = 11)]
        public string SpanishCountryRegionName { get; set; }

        [StringLength(3)]
        [DataMember(Order = 12)]
        public string StateProvinceCode { get; set; }

        [StringLength(50)]
        [DataMember(Order = 13)]
        public string StateProvinceName { get; set; }
    }
}