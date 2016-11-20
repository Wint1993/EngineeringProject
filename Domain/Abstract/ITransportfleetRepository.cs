using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface ITransportfleetRepository
    {
        IEnumerable<Transportfleet> Transportfleets { get; }

        void SaveTransportfleet(Transportfleet transportfleet);

        Transportfleet DeleteTransportfleet(int TranID);
    }
}
