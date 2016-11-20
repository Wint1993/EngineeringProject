using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Domain.Abstract
{
    public interface ICarriageRepository
    {
        IEnumerable<Carriage> Carriagess { get; }

        void SaveCarriage(Carriage carriage);

        Carriage DeleteCarriage(int CarriageID);
    }
}
