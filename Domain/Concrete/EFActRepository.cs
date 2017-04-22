using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFActRepository : IActRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Act> Act
        {
            get { return context.Act; }
        }

    }
}
