namespace LargeData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("DimCurrency")]
    [DataContract(IsReference = true)]
    public partial class Currency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Currency()
        {
            InternetSales = new HashSet<InternetSale>();
        }

        [Required]
        [StringLength(3)]
        [DataMember(Order = 1)]
        public string CurrencyAlternateKey { get; set; }

        [Key]
        [DataMember(Order = 2)]
        public int CurrencyKey { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember(Order = 3)]
        public string CurrencyName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember(Order = 4)]
        virtual public ICollection<InternetSale> InternetSales { get; set; }
    }
}