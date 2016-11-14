using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFPacksRepository : IPacksRepository 
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Packs> Packss
        {
            get { return context.Packss; }
        }

        public IEnumerable<Warehouses> Warehousess
        {
            get { return context.Warehousess; }
        }

        public void SavePacks(Packs packs)
        {
            if (packs.PacksID == 0)
            {
                context.Packss.Add(packs);
            }
            else
            {
                Packs dbEntry = context.Packss.Find(packs.PacksID);
                if (dbEntry != null)
                {
                    dbEntry.Name = packs.Name;
               //     dbEntry.OwnerDescripiton = packs.OwnerDescripiton;
                    dbEntry.wymiarX = packs.wymiarX;
                    dbEntry.wymiarY = packs.wymiarY;
                    dbEntry.wymiarZ = packs.wymiarZ;
                    dbEntry.Waga = packs.Waga;
                    dbEntry.dataprzyjeciadomagazynu = packs.dataprzyjeciadomagazynu;
                    dbEntry.datawyslaniazmagazynu = packs.datawyslaniazmagazynu;
                    dbEntry.dataodebrania = packs.dataodebrania;
                    dbEntry.WarehousesID = packs.WarehousesID;


                }
            }
            context.SaveChanges();
        }

        public Packs DeletePacks(int PacksID)
        {
            Packs dbEntry = context.Packss.Find(PacksID);
            if (dbEntry != null)
            {
                context.Packss.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;


        }



    }
}
