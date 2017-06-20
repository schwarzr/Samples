namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimPromotion")]
    public partial class DimPromotion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimPromotion()
        {
            FactInternetSales = new HashSet<FactInternetSale>();
            FactResellerSales = new HashSet<FactResellerSale>();
        }

        [Key]
        public int PromotionKey { get; set; }

        public int? PromotionAlternateKey { get; set; }

        [StringLength(255)]
        public string EnglishPromotionName { get; set; }

        [StringLength(255)]
        public string SpanishPromotionName { get; set; }

        [StringLength(255)]
        public string FrenchPromotionName { get; set; }

        public double? DiscountPct { get; set; }

        [StringLength(50)]
        public string EnglishPromotionType { get; set; }

        [StringLength(50)]
        public string SpanishPromotionType { get; set; }

        [StringLength(50)]
        public string FrenchPromotionType { get; set; }

        [StringLength(50)]
        public string EnglishPromotionCategory { get; set; }

        [StringLength(50)]
        public string SpanishPromotionCategory { get; set; }

        [StringLength(50)]
        public string FrenchPromotionCategory { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? MinQty { get; set; }

        public int? MaxQty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactInternetSale> FactInternetSales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FactResellerSale> FactResellerSales { get; set; }
    }
}
