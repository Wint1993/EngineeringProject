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
       // public Packs() { }
        public int PacksID { get; set; }
        [Required(ErrorMessage = "Wpisz nazwę paczki")]
        [Display(Name = "Nazwa paczki")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Wpisz szczegóły o paczce")]
        [Display(Name = "Szczegoły")]
        public string OwnerDescription { get; set; }
        //public string OwnerDescripiton { get; set; }
        [Required(ErrorMessage = "Wpisz szerokość paczki")]
        [Display(Name = "Wpisz szerokość paczki w centymetrach [cm]")]
        [Range(0, 99999)]
        public decimal wymiarX { get; set; }
        [Required(ErrorMessage = "Wpisz długość paczki")]
        [Display(Name = "Wpisz długość paczki w centymetrachp [cm]")]
        [Range(0, 99999)]
        public decimal wymiarY { get; set; }
        [Required(ErrorMessage = "Wpisz wysokość paczki")]
        [Display(Name = "Wpisz wysokość paczki w centymetrach [cm]")]
        [Range(0, 99999)]
        public decimal wymiarZ { get; set; }
        [Required(ErrorMessage = "Wpisz wagę paczki")]
        [Display(Name = "Wpisz wagę paczki w kilogramach [kg]")]
        [Range(0, 99999999)]
        public decimal Waga { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Wpisz date w formacie dd-mm-yyyy 00:00:00")]
        [Display(Name = "Data przyjecia paczki do magazynu")]
        public DateTime? dataprzyjeciadomagazynu { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Wpisz date w formacie dd-mm-yyyy 00:00:00")]
        [Display(Name = "Data wyslania z magazynu")]
        public DateTime? datawyslaniazmagazynu { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Wpisz date w formacie dd-mm-yyyy 00:00:00")]
        [Display(Name = "Data odebrania paczki")]
        public DateTime? dataodebrania { get; set; }

        public int WarehousesID { get; set; }
        [ForeignKey("WarehousesID")]
        [Display(Name = "Magazyn")]
        public virtual Warehouses Warehouses { get; set; }

      /*  public int CarriageID { get; set; }
        [ForeignKey("CarriageID")]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "")]
        public Carriage Carriage { get; set; }*/



    }
}
