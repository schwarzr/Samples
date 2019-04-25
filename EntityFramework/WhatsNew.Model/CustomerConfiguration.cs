using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WhatsNew.Model
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsOne(p => p.HomeAddress);
            builder.OwnsOne(p => p.WorkAddress);

            builder.Property<bool>("IsDeleted");
            builder.HasQueryFilter(p => !EF.Property<bool>(p, "IsDeleted"));
        }
    }
}