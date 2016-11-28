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
        /* public int PacksID { get; set; }
         [ForeignKey("PacksID")]
         [HiddenInput(DisplayValue = false)]
         [Display(Name = "")]
         public Packs Packs { get; set; }
         public int personID { get; set; }
         [ForeignKey("personID")]
         [HiddenInput(DisplayValue = false)]
         [Display(Name = "")]
         public Person Person { get; set; }
         public int TranID { get; set; }
         [ForeignKey("TranID")]
         [HiddenInput(DisplayValue = false)]
         [Display(Name = "")]
         public Transportfleet Transportfleet { get; set; }*/

       /* [HiddenInput(DisplayValue = false)]
        [Display(Name = "")]
        public virtual ICollection<Packs> Packsss { get; set; }*/

        /*
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "")]
        public virtual ICollection<Person> Personss { get; set; }*/

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "")]
        public virtual ICollection<Transportfleet> Transportfleetss { get; set; }



    }
}
