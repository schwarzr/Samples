namespace AdventureWorks.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext()
            : base("name=AdventureWorksContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<DatabaseLog> DatabaseLogs { get; set; }

        public virtual DbSet<DimAccount> DimAccounts { get; set; }

        public virtual DbSet<DimCurrency> DimCurrencies { get; set; }

        public virtual DbSet<DimCustomer> DimCustomers { get; set; }

        public virtual DbSet<DimDate> DimDates { get; set; }

        public virtual DbSet<DimDepartmentGroup> DimDepartmentGroups { get; set; }

        public virtual DbSet<DimEmployee> DimEmployees { get; set; }

        public virtual DbSet<DimGeography> DimGeographies { get; set; }

        public virtual DbSet<DimOrganization> DimOrganizations { get; set; }

        public virtual DbSet<DimProductCategory> DimProductCategories { get; set; }

        public virtual DbSet<DimProduct> DimProducts { get; set; }

        public virtual DbSet<DimProductSubcategory> DimProductSubcategories { get; set; }

        public virtual DbSet<DimPromotion> DimPromotions { get; set; }

        public virtual DbSet<DimReseller> DimResellers { get; set; }

        public virtual DbSet<DimSalesReason> DimSalesReasons { get; set; }

        public virtual DbSet<DimSalesTerritory> DimSalesTerritories { get; set; }

        public virtual DbSet<DimScenario> DimScenarios { get; set; }

        public virtual DbSet<FactAdditionalInternationalProductDescription> FactAdditionalInternationalProductDescriptions { get; set; }

        public virtual DbSet<FactCallCenter> FactCallCenters { get; set; }

        public virtual DbSet<FactCurrencyRate> FactCurrencyRates { get; set; }

        public virtual DbSet<FactFinance> FactFinances { get; set; }

        public virtual DbSet<FactInternetSale> FactInternetSales { get; set; }

        public virtual DbSet<FactProductInventory> FactProductInventories { get; set; }

        public virtual DbSet<FactResellerSale> FactResellerSales { get; set; }

        public virtual DbSet<FactSalesQuota> FactSalesQuotas { get; set; }

        public virtual DbSet<FactSurveyResponse> FactSurveyResponses { get; set; }

        public virtual DbSet<ProspectiveBuyer> ProspectiveBuyers { get; set; }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DimAccount>()
                .HasMany(e => e.DimAccount1)
                .WithOptional(e => e.DimAccount2)
                .HasForeignKey(e => e.ParentAccountKey);

            modelBuilder.Entity<DimAccount>()
                .HasMany(e => e.FactFinances)
                .WithRequired(e => e.DimAccount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimCurrency>()
                .Property(e => e.CurrencyAlternateKey)
                .IsFixedLength();

            modelBuilder.Entity<DimCurrency>()
                .HasMany(e => e.FactCurrencyRates)
                .WithRequired(e => e.DimCurrency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimCurrency>()
                .HasMany(e => e.FactInternetSales)
                .WithRequired(e => e.DimCurrency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimCurrency>()
                .HasMany(e => e.FactResellerSales)
                .WithRequired(e => e.DimCurrency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimCustomer>()
                .Property(e => e.MaritalStatus)
                .IsFixedLength();

            modelBuilder.Entity<DimCustomer>()
                .Property(e => e.YearlyIncome)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DimCustomer>()
                .Property(e => e.HouseOwnerFlag)
                .IsFixedLength();

            modelBuilder.Entity<DimCustomer>()
                .HasMany(e => e.FactInternetSales)
                .WithRequired(e => e.DimCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimCustomer>()
                .HasMany(e => e.FactSurveyResponses)
                .WithRequired(e => e.DimCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimDate>()
                .HasMany(e => e.FactCallCenters)
                .WithRequired(e => e.DimDate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimDate>()
                .HasMany(e => e.FactCurrencyRates)
                .WithRequired(e => e.DimDate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimDate>()
                .HasMany(e => e.FactFinances)
                .WithRequired(e => e.DimDate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimDate>()
                .HasMany(e => e.FactInternetSales)
                .WithRequired(e => e.DimDate)
                .HasForeignKey(e => e.OrderDateKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimDate>()
                .HasMany(e => e.FactInternetSales1)
                .WithRequired(e => e.DimDate1)
                .HasForeignKey(e => e.DueDateKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimDate>()
                .HasMany(e => e.FactInternetSales2)
                .WithRequired(e => e.DimDate2)
                .HasForeignKey(e => e.ShipDateKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimDate>()
                .HasMany(e => e.FactProductInventories)
                .WithRequired(e => e.DimDate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimDate>()
                .HasMany(e => e.FactResellerSales)
                .WithRequired(e => e.DimDate)
                .HasForeignKey(e => e.OrderDateKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimDate>()
                .HasMany(e => e.FactResellerSales1)
                .WithRequired(e => e.DimDate1)
                .HasForeignKey(e => e.DueDateKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimDate>()
                .HasMany(e => e.FactResellerSales2)
                .WithRequired(e => e.DimDate2)
                .HasForeignKey(e => e.ShipDateKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimDate>()
                .HasMany(e => e.FactSalesQuotas)
                .WithRequired(e => e.DimDate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimDate>()
                .HasMany(e => e.FactSurveyResponses)
                .WithRequired(e => e.DimDate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimDepartmentGroup>()
                .HasMany(e => e.DimDepartmentGroup1)
                .WithOptional(e => e.DimDepartmentGroup2)
                .HasForeignKey(e => e.ParentDepartmentGroupKey);

            modelBuilder.Entity<DimDepartmentGroup>()
                .HasMany(e => e.FactFinances)
                .WithRequired(e => e.DimDepartmentGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimEmployee>()
                .Property(e => e.MaritalStatus)
                .IsFixedLength();

            modelBuilder.Entity<DimEmployee>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<DimEmployee>()
                .Property(e => e.BaseRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DimEmployee>()
                .HasMany(e => e.DimEmployee1)
                .WithOptional(e => e.DimEmployee2)
                .HasForeignKey(e => e.ParentEmployeeKey);

            modelBuilder.Entity<DimEmployee>()
                .HasMany(e => e.FactResellerSales)
                .WithRequired(e => e.DimEmployee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimEmployee>()
                .HasMany(e => e.FactSalesQuotas)
                .WithRequired(e => e.DimEmployee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimOrganization>()
                .HasMany(e => e.DimOrganization1)
                .WithOptional(e => e.DimOrganization2)
                .HasForeignKey(e => e.ParentOrganizationKey);

            modelBuilder.Entity<DimOrganization>()
                .HasMany(e => e.FactFinances)
                .WithRequired(e => e.DimOrganization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimProduct>()
                .Property(e => e.WeightUnitMeasureCode)
                .IsFixedLength();

            modelBuilder.Entity<DimProduct>()
                .Property(e => e.SizeUnitMeasureCode)
                .IsFixedLength();

            modelBuilder.Entity<DimProduct>()
                .Property(e => e.StandardCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DimProduct>()
                .Property(e => e.ListPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DimProduct>()
                .Property(e => e.ProductLine)
                .IsFixedLength();

            modelBuilder.Entity<DimProduct>()
                .Property(e => e.DealerPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DimProduct>()
                .Property(e => e.Class)
                .IsFixedLength();

            modelBuilder.Entity<DimProduct>()
                .Property(e => e.Style)
                .IsFixedLength();

            modelBuilder.Entity<DimProduct>()
                .HasMany(e => e.FactInternetSales)
                .WithRequired(e => e.DimProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimProduct>()
                .HasMany(e => e.FactProductInventories)
                .WithRequired(e => e.DimProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimProduct>()
                .HasMany(e => e.FactResellerSales)
                .WithRequired(e => e.DimProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimPromotion>()
                .HasMany(e => e.FactInternetSales)
                .WithRequired(e => e.DimPromotion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimPromotion>()
                .HasMany(e => e.FactResellerSales)
                .WithRequired(e => e.DimPromotion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimReseller>()
                .Property(e => e.BusinessType)
                .IsUnicode(false);

            modelBuilder.Entity<DimReseller>()
                .Property(e => e.OrderFrequency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DimReseller>()
                .Property(e => e.AnnualSales)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DimReseller>()
                .Property(e => e.MinPaymentAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DimReseller>()
                .Property(e => e.AnnualRevenue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DimReseller>()
                .HasMany(e => e.FactResellerSales)
                .WithRequired(e => e.DimReseller)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimSalesReason>()
                .HasMany(e => e.FactInternetSales)
                .WithMany(e => e.DimSalesReasons)
                .Map(m => m.ToTable("FactInternetSalesReason").MapLeftKey("SalesReasonKey").MapRightKey(new[] { "SalesOrderNumber", "SalesOrderLineNumber" }));

            modelBuilder.Entity<DimSalesTerritory>()
                .HasMany(e => e.FactInternetSales)
                .WithRequired(e => e.DimSalesTerritory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimSalesTerritory>()
                .HasMany(e => e.FactResellerSales)
                .WithRequired(e => e.DimSalesTerritory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DimScenario>()
                .HasMany(e => e.FactFinances)
                .WithRequired(e => e.DimScenario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FactInternetSale>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactInternetSale>()
                .Property(e => e.ExtendedAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactInternetSale>()
                .Property(e => e.ProductStandardCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactInternetSale>()
                .Property(e => e.TotalProductCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactInternetSale>()
                .Property(e => e.SalesAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactInternetSale>()
                .Property(e => e.TaxAmt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactInternetSale>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactProductInventory>()
                .Property(e => e.UnitCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactResellerSale>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactResellerSale>()
                .Property(e => e.ExtendedAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactResellerSale>()
                .Property(e => e.ProductStandardCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactResellerSale>()
                .Property(e => e.TotalProductCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactResellerSale>()
                .Property(e => e.SalesAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactResellerSale>()
                .Property(e => e.TaxAmt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactResellerSale>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FactSalesQuota>()
                .Property(e => e.SalesAmountQuota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProspectiveBuyer>()
                .Property(e => e.MaritalStatus)
                .IsFixedLength();

            modelBuilder.Entity<ProspectiveBuyer>()
                .Property(e => e.YearlyIncome)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ProspectiveBuyer>()
                .Property(e => e.HouseOwnerFlag)
                .IsFixedLength();
        }
    }
}