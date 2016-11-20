using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUi.Models
{
    public class CarriageIndexViewModel
    {
        public Carriage Carriage { get; set; }
        public string ReturnUrl { get; set; }
    }
}