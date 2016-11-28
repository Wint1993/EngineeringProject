using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Warehouses
    {
        [HiddenInput(DisplayValue = false)]
        public int WarehousesID { get; set; }
        [Required(ErrorMessage = "Wpisz nazwę magazynu")]
        [Display(Name = "Nazwa magazynu")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Wpisz adres")]
        [DataType(DataType.MultilineText), Display(Name = "Adres")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Wpisz numer kontaktowy do magazynu")]
        [Display(Name = "Numer kontaktowy do magazynu")]
        public string Tel { get; set; }
        [Required(ErrorMessage = "Wpisz kod pocztowy")]
        [Display(Name = "Kod pocztowy")]
        public string Postalcode { get; set; }
        [Required(ErrorMessage = "Wpisz NIP")]
        [Display(Name = "NIP")]
        public string NIP { get; set; }

        public Active Active { get; set; }
        [Timestamp]

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "")]
        public virtual ICollection<Packs> Packss { get; set; }
      
      
    }
    public enum Active
    {
        Aktywny,
        Nieaktywny,
    }
}
