namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FactSurveyResponse")]
    public partial class FactSurveyResponse
    {
        [Key]
        public int SurveyResponseKey { get; set; }

        public int DateKey { get; set; }

        public int CustomerKey { get; set; }

        public int ProductCategoryKey { get; set; }

        [Required]
        [StringLength(50)]
        public string EnglishProductCategoryName { get; set; }

        public int ProductSubcategoryKey { get; set; }

        [Required]
        [StringLength(50)]
        public string EnglishProductSubcategoryName { get; set; }

        public DateTime? Date { get; set; }

        public virtual DimCustomer DimCustomer { get; set; }

        public virtual DimDate DimDate { get; set; }
    }
}
