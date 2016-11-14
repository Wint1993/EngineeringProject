using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Abstract;
using WebUi.Models;

namespace WebUi.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository repository;
        public int PageSize = 1;
        public PersonController(IPersonRepository personRepository)
        {
            this.repository = personRepository;
        }

    /*     public ViewResult List(int page =1)
          {
              return View(repository.Persons.OrderBy(p =>p.ID).Skip((page - 1)* PageSize).Take(PageSize));
          }
          */



        public ViewResult List(int page = 1) { 
      PersonListViewModel model = new PersonListViewModel
        {
            Persons = repository.Persons
              .OrderBy(p => p.ID)
              .Skip((page - 1) * PageSize)
              .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                PersonsPerPage = PageSize,
                TotalPersons = repository.Persons.Count()
            }
        };
            return View(model);
    }


    }
}