using System;
using System.Collections.Generic;
using System.Text;
using Ef.DeepDive.Database.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Ef.DeepDive.Database.Context
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options)
            : base(options)
        {
        }

        public EventContext()
        {

        }

        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<Session> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AdcSample; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>().Property(p => p.Id).ValueGeneratedNever();

            var entity = modelBuilder.Entity<Speaker>();

            entity.Property<bool>("IsDeleted")
                .HasDefaultValue(false);
            entity.HasQueryFilter(p => !EF.Property<bool>(p, "IsDeleted"));

            base.OnModelCreating(modelBuilder);




        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
