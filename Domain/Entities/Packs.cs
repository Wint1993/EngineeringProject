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
    public class Packs
    {
        public int PacksID { get; set; }
        public string Name { get; set; }
        //public string OwnerDescripiton { get; set; }
        public decimal wymiarX { get; set; }
        public decimal wymiarY { get; set; }
        public decimal wymiarZ { get; set; }
        public decimal Waga { get; set; }
        public string dataprzyjeciadomagazynu { get; set; }
        public string datawyslaniazmagazynu { get; set; }
        public string dataodebrania { get; set; }
        public int WarehousesID { get; set; }
        [ForeignKey("WarehousesID")]
        public Warehouses Warehouses { get; set; }
        // public virtual ICollection<Carriage> Carriagesss { get; set; }
        [HiddenInput(DisplayValue = false)]
        public virtual ICollection<Carriage> Carriagesss { get; set; }


    }
}
