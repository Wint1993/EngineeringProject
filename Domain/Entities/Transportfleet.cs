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
        [StringLength(50, MinimumLength = 3)]
        public string Carname { get; set; }

        [Required(ErrorMessage = "Wpisz imie i nazwisko kierowcy samochodu")]
        [Display(Name = "Kierowca samochdou")]
        [StringLength(50, MinimumLength = 3)]
        public string Owner { get; set; }
        [Required(ErrorMessage = "Wpisz nazwę modelu")]
        [Display(Name = "Nazwa modelu")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Wpisz maksymalną wagę samochodu")]
        [Display(Name = "Maksymalna waga samochodu")]
        [Range(0, 99999)]
        public decimal Maxcapacity { get; set; }  
        public string Extrainformation { get; set; }
        [Required(ErrorMessage = "Wpisz numer rejestracyjny")]
        [Display(Name = "Numer rejestracyjny")]
        public string Registrationnumber { get; set; }
        [Required(ErrorMessage = "Wpisz numer VIN")]
        [Display(Name = "Numer VIN")]
        public string VIN { get; set; }

        [Display(Name = "Aktywność")]
        public int actID { get; set; }
        [ForeignKey("actID")]
        [Display(Name = "Aktywność")]
        public virtual Act Act { get; set; }



     

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "")]
        public virtual ICollection<Carriage> Carriagess { get; set; }


    }

}
