using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Transportfleet
    {
        [Key]
        public int TranID { get; set; }
        public string Carname { get; set; }
        public string Owner { get; set; }
        public string Model { get; set; }
        public decimal Maxcapacity { get; set; }
        public string Extrainformation { get; set; }
        public string Registrationnumber { get; set; }
        public string VIN { get; set; }
        public string Active { get; set; }
        [HiddenInput(DisplayValue = false)]
        public virtual ICollection<Carriage> Carriagesss { get; set; }



    }
}
