using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFWarehousesRepository : IWarehousesRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Warehouses> Warehousess
        {
            get { return context.Warehousess; }
        }
      

        public void SaveWarehouses(Warehouses warehouses)
        {
            if (warehouses.WarehousesID == 0)
            {
                context.Warehousess.Add(warehouses);
            }
            else
            {
                Warehouses dbEntry = context.Warehousess.Find(warehouses.WarehousesID);
                if (dbEntry != null)
                {
                    dbEntry.Name = warehouses.Name;
                    dbEntry.Adress = warehouses.Adress;
                    dbEntry.Tel = warehouses.Tel;
                    dbEntry.Email = warehouses.Email;
                    dbEntry.Postalcode = warehouses.Postalcode;
                    dbEntry.NIP = warehouses.NIP;
                 

                }
            }
            context.SaveChanges();
        }

        public Warehouses DeleteWarehouses(int WarehousesID)
        {
            Warehouses dbEntry = context.Warehousess.Find(WarehousesID);
            if (dbEntry != null)
            {
                context.Warehousess.Remove(dbEntry);
                context.SaveChanges();
                
            }
            return dbEntry;


        }
    }
}
