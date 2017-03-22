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
       
        public Carriage()
        {
            this.Packss = new HashSet<Packs>();
        }
        public int CarriageID { get; set; }
       
        [Required(ErrorMessage = "Wpisz nazwę danego transportu")]
        [Display(Name = "Nazwa transportu")]
        [StringLength(50, MinimumLength = 3)]
        public string Target { get; set; }


        [Required(ErrorMessage = "Wpisz kiedy przesyłka ma zostać wysłana")]
        [Display(Name = "Zamierzona data wysłania")]
        [StringLength(50, MinimumLength = 3)]
        public string zamierzonadatawyslania { get; set; }

        [Required(ErrorMessage = "Wpisz kiedy przesyłka ma zostać odebrana")]
        [Display(Name = "Zamierzona data odebrania")]
        [StringLength(50, MinimumLength = 3)]
        public string rzeczywistadatawyslania { get; set; }

        [Required(ErrorMessage = "Wpisz szczegóły")]
        [Display(Name = "Dodatkowe informacje")]
        public string OwnerDescription { get; set; }

        [Required(ErrorMessage = "Wybierz transport z dostępnych")]
        [Display(Name = "Transport")]
        public int TranID { get; set; }
        [ForeignKey("TranID")]
        [Display(Name = "Transport")]
        public virtual Transportfleet Transportfleet { get; set; }


    
        public virtual ICollection<Packs> Packss { get; set; }




        [Display(Name = "Skąd")]
        public int WarehousesID { get; set; }
        [ForeignKey("WarehousesID")]
        [Display(Name = "Skąd")]
        public virtual Warehouses Warehouses { get; set; }


      


    }
}
