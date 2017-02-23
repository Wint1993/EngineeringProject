using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete;
using System.Data.Entity;
using PagedList;

namespace WebUi.Controllers
{
    public class ActController : Controller
    {
        // GET: Act
        private IPersonRepository repository;
        private EFDbContext db = new EFDbContext();

        public ActController(IPersonRepository repo)
        {
            repository = repo;

        }
    }
}