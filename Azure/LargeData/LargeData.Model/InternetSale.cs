namespace LargeData.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("FactInternetSales")]
    [DataContract(IsReference = true)]
    public partial class InternetSale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InternetSale()
        {
            InternetSalesReasons = new HashSet<InternetSalesReason>();
        }

        [StringLength(25)]
        [DataMember(Order = 1)]
        public string CarrierTrackingNumber { get; set; }

        [DataMember(Order = 2)]
        virtual public Currency Currency { get; set; }

        [DataMember(Order = 3)]
        public int CurrencyKey { get; set; }

        [DataMember(Order = 4)]
        virtual public Customer Customer { get; set; }

        [DataMember(Order = 5)]
        public int CustomerKey { get; set; }

        [StringLength(25)]
        [DataMember(Order = 6)]
        public string CustomerPONumber { get; set; }

        [DataMember(Order = 7)]
        public double DiscountAmount { get; set; }

        [DataMember(Order = 8)]
        public DateTime? DueDate { get; set; }

        [DataMember(Order = 9)]
        virtual public DateEntity DueDateEntity { get; set; }

        [DataMember(Order = 10)]
        public int DueDateKey { get; set; }

        [Column(TypeName = "money")]
        [DataMember(Order = 11)]
        public decimal ExtendedAmount { get; set; }

        [Column(TypeName = "money")]
        [DataMember(Order = 12)]
        public decimal Freight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DataMember(Order = 13)]
        virtual public ICollection<InternetSalesReason> InternetSalesReasons { get; set; }

        [DataMember(Order = 14)]
        public DateTime? OrderDate { get; set; }

        [DataMember(Order = 15)]
        virtual public DateEntity OrderDateEntity { get; set; }

        [DataMember(Order = 16)]
        public int OrderDateKey { get; set; }

        [DataMember(Order = 17)]
        public short OrderQuantity { get; set; }

        [DataMember(Order = 18)]
        public int ProductKey { get; set; }

        [Column(TypeName = "money")]
        [DataMember(Order = 19)]
        public decimal ProductStandardCost { get; set; }

        [DataMember(Order = 20)]
        virtual public Promotion Promotion { get; set; }

        [DataMember(Order = 21)]
        public int PromotionKey { get; set; }

        [DataMember(Order = 22)]
        public byte RevisionNumber { get; set; }

        [Column(TypeName = "money")]
        [DataMember(Order = 23)]
        public decimal SalesAmount { get; set; }

        [Key]
        [Column(Order = 1)]
        [DataMember(Order = 24)]
        public byte SalesOrderLineNumber { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        [DataMember(Order = 25)]
        public string SalesOrderNumber { get; set; }

        [DataMember(Order = 26)]
        virtual public SalesTerritory SalesTerritory { get; set; }

        [DataMember(Order = 27)]
        public int SalesTerritoryKey { get; set; }

        [DataMember(Order = 28)]
        public DateTime? ShipDate { get; set; }

        [DataMember(Order = 29)]
        virtual public DateEntity ShipDateEntity { get; set; }

        [DataMember(Order = 30)]
        public int ShipDateKey { get; set; }

        [Column(TypeName = "money")]
        [DataMember(Order = 31)]
        public decimal TaxAmt { get; set; }

        [Column(TypeName = "money")]
        [DataMember(Order = 32)]
        public decimal TotalProductCost { get; set; }

        [Column(TypeName = "money")]
        [DataMember(Order = 33)]
        public decimal UnitPrice { get; set; }

        [DataMember(Order = 34)]
        public double UnitPriceDiscountPct { get; set; }
    }
}