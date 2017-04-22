using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Warehouses> Warehousess { get; set; }
        public DbSet<Transportfleet> Transportfleets { get; set; }
        public DbSet<Packs> Packss { get; set; }
        public DbSet<Carriage> Carriagess { get; set; }
        public DbSet<Act> Act { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //  modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Packs>()
                .HasMany(c => c.Carriagess).WithMany(i => i.Packss)
                .Map(t => t.MapLeftKey("PacksID")
                    .MapRightKey("CarriageID")
                    .ToTable("PacksCarriages"));
            modelBuilder.Entity<Act>().MapToStoredProcedures();
            //modelBuilder.Entity<Person>().MapToStoredProcedures();
            //modelBuilder.Entity<Warehouses>().MapToStoredProcedures();
            modelBuilder.Entity<Transportfleet>().MapToStoredProcedures();

            modelBuilder.Entity<Act>().HasMany(x => x.Warehouses).WithMany();
            modelBuilder.Entity<Packs>().HasOptional(p => p.Person).WithMany(t => t.Packss).Map(c => c.MapKey("actID"));
            modelBuilder.Entity<Packs>().HasOptional(p => p.Warehouses).WithMany(t => t.Packss).Map(c => c.MapKey("WarehousesID"));

            // modelBuilder.Entity<Transportfleet>()
            //    .HasKey(e => e.TranID);*/
            // base.OnModelCreating(modelBuilder);

            /* modelBuilder.Entity<Carriage>()
                 .HasOptional(c => c.Transportfleet)
                 .WithRequired(ad => ad.TranID);*/






        }


    }
}
