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
        public DbSet<Act> Acts { get; set; }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Packs>()
                .HasMany(c => c.Carriagess).WithMany(i => i.Packss)
                .Map(t => t.MapLeftKey("PacksID")
                    .MapRightKey("CarriageID")
                    .ToTable("PacksCarriage"));

            modelBuilder.Entity<Transportfleet>()
                .HasKey(e => e.TranID);

           /* modelBuilder.Entity<Carriage>()
                .HasOptional(c => c.Transportfleet)
                .WithRequired(ad => ad.TranID);*/

            modelBuilder.Entity<Transportfleet>().MapToStoredProcedures();
        }
        

    }
}
