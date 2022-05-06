using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalAzure.CustomSchema.Data.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace GlobalAzure.CustomSchema.Database
{
    public class CrmContext : DbContext
    {
        public CrmContext(DbContextOptions options, MetadataModel customization)
            : base(options)
        {
            CustomizationModel = customization;
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Customization> Customizations { get; set; }

        public MetadataModel CustomizationModel { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ReplaceService<IModelCacheKeyFactory, CustomizationModelCacheKeyFactory>();
            optionsBuilder.ReplaceService<IQueryCompiler, CustomQueryCompiler>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>();
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Customization>();

            AddCustomization(modelBuilder);

        }

        private void AddCustomization(ModelBuilder modelBuilder)
        {
            var model = modelBuilder.Model;
            foreach (var entity in model.GetEntityTypes())
            {
                var customization = CustomizationModel.Entities.FirstOrDefault(p => p.EntityName == entity.Name);
                if (customization != null)
                {
                    var builder = modelBuilder.Entity(entity.ClrType);
                    foreach (var property in customization.Properties)
                    {
                        builder.Property(GetClrType(property), property.Name)
                            .IsRequired(!property.IsNullable);
                    }
                }
            }
        }

        public static Type GetClrType(PropertyMetadata property)
        {
            switch (property.PropertyType)
            {
                case PropertyType.String:
                    return typeof(string);
                case PropertyType.Int:
                    return property.IsNullable ? typeof(int?) : typeof(int);
                case PropertyType.Decimal:
                    return property.IsNullable ? typeof(decimal?) : typeof(decimal);
                case PropertyType.DateTime:
                case PropertyType.Date:
                    return property.IsNullable ? typeof(DateTime?) : typeof(DateTime);
                case PropertyType.Boolean:
                    return property.IsNullable ? typeof(bool?) : typeof(bool);
            }


            throw new NotSupportedException();
        }

        private class CustomizationModelCacheKeyFactory : ModelCacheKeyFactory
        {
            public CustomizationModelCacheKeyFactory(ModelCacheKeyFactoryDependencies dependencies)
                : base(dependencies)
            {
            }

            public override object Create(DbContext context, bool designTime)
            {
                if (context is CrmContext crmContext)
                {
                    return $"{crmContext.CustomizationModel.Version}_{designTime}";
                }

                return base.Create(context, designTime);
            }

            public override object Create(DbContext context)
            {
                if (context is CrmContext crmContext)
                {
                    return crmContext.CustomizationModel.Version;
                }

                return base.Create(context);
            }
        }
    }
}
