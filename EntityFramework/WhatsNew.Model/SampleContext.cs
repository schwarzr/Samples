using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WhatsNew.Model.Translation;

namespace WhatsNew.Model
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ReplaceService<IEntityStateListener, TranslationStateManager>();
            optionsBuilder.ReplaceService<IQueryCompiler, TranslationQueryCompiler>();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            var builder = modelBuilder.Entity<Invoice>();
            builder.Property<bool>("IsDeleted");
            builder.HasQueryFilter(p => !EF.Property<bool>(p, "IsDeleted"));

            var prop = from e in modelBuilder.Model.GetEntityTypes()
                       from p in e.GetProperties()
                       where p.Name == "Name"
                       select new { Entity = e, Property = p };

            foreach (var entity in prop.ToList())
            {
                var e = modelBuilder.Entity(entity.Entity.ClrType);

                foreach (var lang in new[] { "de", "en" })
                {
                    var newprop = e.Property(entity.Property.ClrType, $"{entity.Property.Name}_{lang}");
                    var length = entity.Property.GetMaxLength();
                    if (length.HasValue)
                    {
                        newprop.HasMaxLength(length.Value);
                    }

                    newprop.IsRequired(!entity.Property.IsNullable);
                }
                e.Ignore(entity.Property.Name);
            }
        }
    }
}