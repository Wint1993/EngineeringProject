using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Carriage
    {
        public int CarriageID { get; set; }
        public string Name { get; set; }
        public string zamierzonadatawyslania { get; set; }
        public string rzeczywistadatawyslania { get; set; }
        public string zamierzonadataodebrania { get; set; }
        public string rzeczywistadataodebrania { get; set; }
        public int PacksID { get; set; }
        [ForeignKey("PacksID")]
        public Packs Packs { get; set; }
        public int personID { get; set; }
        [ForeignKey("personID")]
        public Person Person { get; set; }
        public int TranID { get; set; }
        [ForeignKey("TranID")]
        public Transportfleet Transportfleet { get; set; }

        

    }
}
