namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimProductCategory")]
    public partial class DimProductCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DimProductCategory()
        {
            DimProductSubcategories = new HashSet<DimProductSubcategory>();
        }

        [Key]
        public int ProductCategoryKey { get; set; }

        public int? ProductCategoryAlternateKey { get; set; }

        [Required]
        [StringLength(50)]
        public string EnglishProductCategoryName { get; set; }

        [Required]
        [StringLength(50)]
        public string SpanishProductCategoryName { get; set; }

        [Required]
        [StringLength(50)]
        public string FrenchProductCategoryName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DimProductSubcategory> DimProductSubcategories { get; set; }
    }
}
