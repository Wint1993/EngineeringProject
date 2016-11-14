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
        public int ID { get; set; }
        public string Carname { get; set; }
        public string Owner { get; set; }
        public string Model { get; set; }
        public decimal Maxcapacity { get; set; }
        public string Extrainformation { get; set; }
        public string Registrationnumber { get; set; }
        public string VIN { get; set; }
        public string Active { get; set; }
        
     


    }
}
