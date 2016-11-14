using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFPersonRepository : IPersonRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Person> Persons
        {
            get { return context.Persons; }
        }

        public void SavePerson(Person person)
        {
            if(person.ID == 0)
            {
                context.Persons.Add(person);
            } 
            else
            {
                Person dbEntry = context.Persons.Find(person.ID);
                if(dbEntry != null)
                {
                    dbEntry.Name = person.Name;
                    dbEntry.Adress = person.Adress;
                    dbEntry.Tel = person.Tel;
                    dbEntry.Email = person.Email;
                    dbEntry.Country = person.Country;
                    dbEntry.State = person.State;
                    dbEntry.Concern = person.Concern;
                    dbEntry.ConcernAdress = person.ConcernAdress;
                    dbEntry.Postalcode = person.Postalcode;
                    dbEntry.NIP = person.NIP;
                    dbEntry.Pesel = person.Pesel;

                }
            }
            context.SaveChanges();
        }

        public Person DeletePerson(int ID)
        {
            Person dbEntry = context.Persons.Find(ID);
            if (dbEntry != null)
            {
                context.Persons.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;         


        }

    }
}
