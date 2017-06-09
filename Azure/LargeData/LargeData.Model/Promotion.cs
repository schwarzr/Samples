namespace LargeData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("DimPromotion")]
    [DataContract(IsReference = true)]
    public partial class Promotion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promotion()
        {
            InternetSales = new HashSet<InternetSale>();
        }

        [DataMember(Order = 1)]
        public double? DiscountPct { get; set; }

        [DataMember(Order = 2)]
        public DateTime? EndDate { get; set; }

        [StringLength(50)]
        [DataMember(Order = 3)]
        public string EnglishPromotionCategory { get; set; }

        [StringLength(255)]
        [DataMember(Order = 4)]
        public string EnglishPromotionName { get; set; }

        [StringLength(50)]
        [DataMember(Order = 5)]
        public string EnglishPromotionType { get; set; }

        [StringLength(50)]
        [DataMember(Order = 6)]
        public string FrenchPromotionCategory { get; set; }

        [StringLength(255)]
        [DataMember(Order = 7)]
        public string FrenchPromotionName { get; set; }

        [StringLength(50)]
        [DataMember(Order = 8)]
        public string FrenchPromotionType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember(Order = 9)]
        virtual public ICollection<InternetSale> InternetSales { get; set; }

        [DataMember(Order = 10)]
        public int? MaxQty { get; set; }

        [DataMember(Order = 11)]
        public int? MinQty { get; set; }

        [DataMember(Order = 12)]
        public int? PromotionAlternateKey { get; set; }

        [Key]
        [DataMember(Order = 13)]
        public int PromotionKey { get; set; }

        [StringLength(50)]
        [DataMember(Order = 14)]
        public string SpanishPromotionCategory { get; set; }

        [StringLength(255)]
        [DataMember(Order = 15)]
        public string SpanishPromotionName { get; set; }

        [StringLength(50)]
        [DataMember(Order = 16)]
        public string SpanishPromotionType { get; set; }

        [DataMember(Order = 17)]
        public DateTime StartDate { get; set; }
    }
}