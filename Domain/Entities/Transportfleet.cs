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
    public class Transportfleet
    {
        [Key]
        public int TranID { get; set; }
        [Required(ErrorMessage = "Wpisz nazwę samochodu")]
        [Display(Name = "Nazwa samochodu")]
        public string Carname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Wpisz date w formacie dd-mm-yyyy 00:00:00")]

        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Wpisz imie i nazwisko kierowcy samochodu")]
        [Display(Name = "Kierowca samochdou")]
        public string Owner { get; set; }
        [Required(ErrorMessage = "Wpisz nazwę modelu")]
        [Display(Name = "Nazwa modelu")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Wpisz maksymalną wagę samochodu")]
        [Display(Name = "Maksymalna waga samochodu")]
        public decimal Maxcapacity { get; set; }  
        public string Extrainformation { get; set; }
        [Required(ErrorMessage = "Wpisz numer rejestracyjny")]
        [Display(Name = "Numer rejestracyjny")]
        public string Registrationnumber { get; set; }
        [Required(ErrorMessage = "Wpisz numer VIN")]
        [Display(Name = "Numer VIN")]
        public string VIN { get; set; }
        public Active Active { get; set; }
        public int CarriageID { get; set; }
        [ForeignKey("CarriageID")]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "")]
        public Carriage Carriage { get; set; }



    }

}
