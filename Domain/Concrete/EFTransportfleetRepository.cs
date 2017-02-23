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
            if (transportfleet.TranID == 0)
            {
                context.Transportfleets.Add(transportfleet);
            }
            else
            {
                Transportfleet dbEntry = context.Transportfleets.Find(transportfleet.TranID);
                if (dbEntry != null)
                {
                    
                    dbEntry.Carname = transportfleet.Carname;
                    dbEntry.Owner = transportfleet.Owner;
                    dbEntry.Extrainformation = transportfleet.Extrainformation;
                    dbEntry.Model = transportfleet.Model;
                    dbEntry.Maxcapacity = transportfleet.Maxcapacity;
                    dbEntry.Registrationnumber = transportfleet.Registrationnumber;
                    dbEntry.VIN = transportfleet.VIN;
                   
                    dbEntry.actID = transportfleet.actID;
                }
            }
            context.SaveChanges();
        }

        public Transportfleet DeleteTransportfleet(int TranID)
        {
            Transportfleet dbEntry = context.Transportfleets.Find(TranID);
            if (dbEntry != null)
            {
                context.Transportfleets.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;


        }
    }
}
