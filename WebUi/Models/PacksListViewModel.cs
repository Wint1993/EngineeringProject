using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUi.Models
{
    public class PacksListViewModel
    {
        public IEnumerable<Packs> Packss { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}