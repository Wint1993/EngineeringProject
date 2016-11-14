using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFTransportfleetRepository : ITransportfleetRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Transportfleet> Transportfleets
        {
            get { return context.Transportfleets; }
        }

        public void SaveTransportfleet(Transportfleet transportfleet)
        {
            if (transportfleet.ID == 0)
            {
                context.Transportfleets.Add(transportfleet);
            }
            else
            {
                Transportfleet dbEntry = context.Transportfleets.Find(transportfleet.ID);
                if (dbEntry != null)
                {
                    dbEntry.Carname = transportfleet.Carname;
                    dbEntry.Owner = transportfleet.Owner;
                    dbEntry.Extrainformation = transportfleet.Extrainformation;
                    dbEntry.Model = transportfleet.Model;
                    dbEntry.Maxcapacity = transportfleet.Maxcapacity;
                    dbEntry.Registrationnumber = transportfleet.Registrationnumber;
                    dbEntry.VIN = transportfleet.VIN;
                    dbEntry.Active = transportfleet.Active;

                }
            }
            context.SaveChanges();
        }

        public Transportfleet DeleteTransportfleet(int ID)
        {
            Transportfleet dbEntry = context.Transportfleets.Find(ID);
            if (dbEntry != null)
            {
                context.Transportfleets.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;


        }
    }
}
