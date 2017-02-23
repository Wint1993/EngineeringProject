using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Person
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int personID { get; set; }

        [Required(ErrorMessage ="Wpisz imię i nazwisko")]
        [Display(Name="Imię i nazwisko")]
        [StringLength(50, MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wpisz adres")]
        [DataType(DataType.MultilineText),Display(Name="Adres")]
        [StringLength(50, MinimumLength = 3)]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Wpisz numer kontaktowy")]
        [Display(Name = "Numer kontaktowy")]
        [StringLength(50, MinimumLength = 9)]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Wpisz adres email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę państwa")]
        [Display(Name = "Państwo")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę województwa")]
        [Display(Name = "Województwo")]
        public string State { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę firmy")]
        [Display(Name = "Firma")]
        public string Concern { get; set; }

        [Required(ErrorMessage = "Wpisz adres firmy")]
        [DataType(DataType.MultilineText), Display(Name = "Adres firmy")]
        public string ConcernAdress { get; set; }

        [Required(ErrorMessage = "Wpisz kod pocztowy")]
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Wpisz NIP")]
        [Display(Name = "NIP")]
        public string NIP { get; set; }

        [Required(ErrorMessage = "Wpisz Pesel")]
        [Display(Name = "Pesel")]
        public string Pesel { get; set; }


        [HiddenInput(DisplayValue = false)]
        [Display(Name = "")]
        public virtual ICollection<Packs> Packss { get; set; }



    }
}
