namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimSalesReason")]
    public partial class DimSalesReason
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimSalesReason()
        {
            FactInternetSales = new HashSet<FactInternetSale>();
        }

        [Key]
        public int SalesReasonKey { get; set; }

        public int SalesReasonAlternateKey { get; set; }

        [Required]
        [StringLength(50)]
        public string SalesReasonName { get; set; }

        [Required]
        [StringLength(50)]
        public string SalesReasonReasonType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactInternetSale> FactInternetSales { get; set; }
    }
}
