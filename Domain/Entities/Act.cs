using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Act
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int actID { get; set; }
        public string Active { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "")]
        public virtual ICollection<Transportfleet> Transportfleets { get; set; }
        public virtual ICollection<Warehouses> Warehouses { get; set; }
        
    }
}
