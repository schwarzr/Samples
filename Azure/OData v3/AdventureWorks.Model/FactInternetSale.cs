namespace AdventureWorks.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FactInternetSale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FactInternetSale()
        {
            DimSalesReasons = new HashSet<DimSalesReason>();
        }

        public int ProductKey { get; set; }

        public int OrderDateKey { get; set; }

        public int DueDateKey { get; set; }

        public int ShipDateKey { get; set; }

        public int CustomerKey { get; set; }

        public int PromotionKey { get; set; }

        public int CurrencyKey { get; set; }

        public int SalesTerritoryKey { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string SalesOrderNumber { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte SalesOrderLineNumber { get; set; }

        public byte RevisionNumber { get; set; }

        public short OrderQuantity { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal ExtendedAmount { get; set; }

        public double UnitPriceDiscountPct { get; set; }

        public double DiscountAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal ProductStandardCost { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalProductCost { get; set; }

        [Column(TypeName = "money")]
        public decimal SalesAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal TaxAmt { get; set; }

        [Column(TypeName = "money")]
        public decimal Freight { get; set; }

        [StringLength(25)]
        public string CarrierTrackingNumber { get; set; }

        [StringLength(25)]
        public string CustomerPONumber { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? ShipDate { get; set; }

        public virtual DimCurrency DimCurrency { get; set; }

        public virtual DimCustomer DimCustomer { get; set; }

        public virtual DimDate DimDate { get; set; }

        public virtual DimDate DimDate1 { get; set; }

        public virtual DimDate DimDate2 { get; set; }

        public virtual DimProduct DimProduct { get; set; }

        public virtual DimPromotion DimPromotion { get; set; }

        public virtual DimSalesTerritory DimSalesTerritory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DimSalesReason> DimSalesReasons { get; set; }
    }
}
