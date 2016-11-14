using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUi.Controllers
{
    public class AdminController : Controller
    {
        private IPersonRepository repository;

        public AdminController(IPersonRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.Persons);
        }

        public ViewResult Index2()
        {
            return View(repository.Persons);
        }


        public ViewResult Edit(int? ID)
        {
            Person person = repository.Persons.FirstOrDefault(p => p.ID == ID);
            return View(person);

        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                repository.SavePerson(person);
                TempData["message"] = string.Format("Zapisano {0} ", person.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(person);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Person());
        }

      

        public ActionResult Details(int? ID)
        {

            Person person = repository.Persons.FirstOrDefault(p => p.ID == ID);
            return View(person);
        }


        [HttpPost]
        public ActionResult Delete(int ID)
        {
            Person delPerson = repository.DeletePerson(ID);
            if (delPerson != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", delPerson.Name);
            } return RedirectToAction("Index");
        }

    }
}