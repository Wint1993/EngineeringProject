using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUi.Models
{
    public class PersonListViewModel
    {

        public IEnumerable<Person> Persons { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}