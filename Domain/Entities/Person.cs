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
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Required(ErrorMessage ="Wpisz imię i nazwisko")]
        [Display(Name="Imię i nazwisko")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wpisz adres")]
        [DataType(DataType.MultilineText),Display(Name="Adres")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Wpisz numer kontaktowy")]
        [Display(Name = "Numer kontaktowy")]
        public decimal Tel { get; set; }

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
        public decimal Postalcode { get; set; }

        [Required(ErrorMessage = "Wpisz NIP")]
        [Display(Name = "NIP")]
        public decimal NIP { get; set; }

        [Required(ErrorMessage = "Wpisz Pesel")]
        [Display(Name = "Pesel")]
        public decimal Pesel { get; set; }

    }
}
