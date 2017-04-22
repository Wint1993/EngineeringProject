using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete;

namespace WebUi.ViewModel
{
    public class CarriageIndexData
    {

        public IEnumerable<Carriage> Carriagess { get; set; }
      
        public IEnumerable<Packs> Packss { get; set; }
       
    }
}