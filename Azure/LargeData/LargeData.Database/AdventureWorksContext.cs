namespace LargeData.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using LargeData.Model;

    public partial class AdventureWorksContext : DbContext
    {
        static AdventureWorksContext()
        {
            System.Data.Entity.Database.SetInitializer<AdventureWorksContext>(new NullDatabaseInitializer<AdventureWorksContext>());
        }

        public AdventureWorksContext(string connectionStringOrName) : base(connectionStringOrName)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
        }

        public AdventureWorksContext()
            : this("name=AdventureWorksContext")
        {
        }

        public virtual DbSet<Currency> Currencies { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<DateEntity> Dates { get; set; }

        public virtual DbSet<Geography> Geographies { get; set; }

        public virtual DbSet<InternetSale> InternetSales { get; set; }

        public virtual DbSet<InternetSalesReason> InternetSalesReasons { get; set; }

        public virtual DbSet<Promotion> Promotions { get; set; }

        public virtual DbSet<SalesTerritory> SalesTerritories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .Property(e => e.CurrencyAlternateKey)
                .IsFixedLength();

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.InternetSales)
                .WithRequired(e => e.Currency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.MaritalStatus)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.YearlyIncome)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .Property(e => e.HouseOwnerFlag)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.InternetSales)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DateEntity>()
                .HasMany(e => e.OrderDateSales)
                .WithRequired(e => e.OrderDateEntity)
                .HasForeignKey(e => e.OrderDateKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DateEntity>()
                .HasMany(e => e.DueDateSales)
                .WithRequired(e => e.DueDateEntity)
                .HasForeignKey(e => e.DueDateKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DateEntity>()
                .HasMany(e => e.ShipDateSales)
                .WithRequired(e => e.ShipDateEntity)
                .HasForeignKey(e => e.ShipDateKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Promotion>()
                .HasMany(e => e.InternetSales)
                .WithRequired(e => e.Promotion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalesTerritory>()
                .HasMany(e => e.InternetSales)
                .WithRequired(e => e.SalesTerritory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InternetSale>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<InternetSale>()
                .Property(e => e.ExtendedAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<InternetSale>()
                .Property(e => e.ProductStandardCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<InternetSale>()
                .Property(e => e.TotalProductCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<InternetSale>()
                .Property(e => e.SalesAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<InternetSale>()
                .Property(e => e.TaxAmt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<InternetSale>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<InternetSale>()
                .HasMany(e => e.InternetSalesReasons)
                .WithRequired(e => e.InternetSale)
                .HasForeignKey(e => new { e.SalesOrderNumber, e.SalesOrderLineNumber })
                .WillCascadeOnDelete(false);
        }
    }
}