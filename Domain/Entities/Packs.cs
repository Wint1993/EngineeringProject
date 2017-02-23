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
        [Display(Name = "Nazwa przesyłki")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Wpisz szczegóły")]
        [Display(Name = "Dodatkowe informacje")]
        public string OwnerDescription { get; set; }


        [Required(ErrorMessage = "Wpisz szerokość paczki w centymetrach [cm]")]
        [Display(Name = "Szerokość paczki [cm]")]
        [Range(0, 99999)]
        public decimal wymiarX { get; set; }



        [Required(ErrorMessage = "Wpisz długość paczki w centymetrach [cm]")]
        [Display(Name = "Długość paczki [cm]")]
        [Range(0, 99999)]
        public decimal wymiarY { get; set; }



        [Required(ErrorMessage = "Wpisz wysokość paczki w centymetrach [cm]")]
        [Display(Name = "Wysokość paczki [cm]")]
        [Range(0, 99999)]
        public decimal wymiarZ { get; set; }



        [Required(ErrorMessage = "Wpisz wagę paczki w kilogramach [kg]")]
        [Display(Name = "Waga paczki [kg]")]
        [Range(0, 99999999)]
        public decimal Waga { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Wpisz date w formacie dd-mm-yyyy 00:00:00")]
        [Display(Name = "Data wyjazdu transportu")]
        public DateTime? dataprzyjeciadomagazynu { get; set; }



        [DataType(DataType.Date)]
      //  [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
       // [Required(ErrorMessage = "Wpisz date w formacie dd-mm-yyyy 00:00:00")]
        [Display(Name = "Data odbioru transportu")]
        public DateTime? datawyslaniazmagazynu { get; set; }



        [DataType(DataType.Date)]
       //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
       // [Required(ErrorMessage = "Wpisz date w formacie dd-mm-yyyy 00:00:00")]
        [Display(Name = "Data odebrania paczki")]
        public DateTime? dataodebrania { get; set; }



        [Display(Name = "Magazyn")]
        public int WarehousesID { get; set; }
        [ForeignKey("WarehousesID")]
        [Display(Name = "Magazyn")]
        public virtual Warehouses Warehouses { get; set; }


        [Display(Name = "Klient")]
        public int personID { get; set; }
        [ForeignKey("personID")]
        [Display(Name = "Klient")]
        public virtual Person Person { get; set; }


   

        [Display(Name = "Carriage")]
        public virtual int? CarriageID { get; set; }
        [ForeignKey("CarriageID")]
        [Display(Name = "Carriage")]
        public virtual Carriage Carriage { get; set; }






    }
}
