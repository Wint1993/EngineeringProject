using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUi.Models
{
    public class PagingInfo
    {
        public int TotalPersons { get; set; }
        public int PersonsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalPersons / PersonsPerPage); }
        }
    }
}