using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Warehouses> Warehousess { get; set; }
        public DbSet<Transportfleet> Transportfleets { get; set; }
        public DbSet<Packs> Packss { get; set; }
    }
}
