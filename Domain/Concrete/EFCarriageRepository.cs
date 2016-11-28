using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFCarriageRepository : ICarriageRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Carriage> Carriagess
        {
            get { return context.Carriagess; }
        }

   

        public void SaveCarriage(Carriage carriage)
        {
            if (carriage.CarriageID == 0)
            {
                context.Carriagess.Add(carriage);
            }
            else
            {

                Carriage dbEntry = context.Carriagess.Find(carriage.CarriageID);
                if (dbEntry != null)
                {
                    dbEntry.Name = carriage.Name;
                    dbEntry.zamierzonadatawyslania = carriage.zamierzonadatawyslania;
                    dbEntry.rzeczywistadatawyslania = carriage.rzeczywistadatawyslania;
                    dbEntry.zamierzonadataodebrania = carriage.zamierzonadataodebrania;
                    dbEntry.rzeczywistadataodebrania = carriage.rzeczywistadataodebrania;
                   


                }
            }
            context.SaveChanges();
        }

        public Carriage DeleteCarriage(int CarriageID)

        {
            Carriage dbEntry = context.Carriagess.Find(CarriageID);
            if (dbEntry != null)
            {
                context.Carriagess.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;


        }
    }
}
