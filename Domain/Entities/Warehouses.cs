using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Warehouses
    {
        [HiddenInput(DisplayValue = false)]
        public int WarehousesID { get; set; }
        public string Name { get; set; }

        public string Adress { get; set; }

        public decimal Tel { get; set; }

        public string Email { get; set; }
        public decimal Postalcode { get; set; }
        public decimal NIP { get; set; }
        public string Active { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual ICollection<Packs> Packsss { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
