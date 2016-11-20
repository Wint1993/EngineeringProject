using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUi.Models
{
    public class PacksIndexViewModel
    {
        public CarriageCart CarriageCart { get; set; }
        public string ReturnUrl { get; set; }
    }
}