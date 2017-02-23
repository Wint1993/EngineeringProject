﻿using System;
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
    public class AdminController : Controller
    {
        private IPersonRepository repository;
        private EFDbContext db = new EFDbContext();

        public AdminController(IPersonRepository repo)
        {
            repository = repo;
          
        }


        [HttpGet]
        public ActionResult Index(string presentfilt, string searchString, int? page)
        {




            IQueryable<Person> person = db.Persons;
                                   
          

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = presentfilt;
            }

            ViewBag.CurrentFilter = searchString;


            if (!String.IsNullOrEmpty(searchString))
            {
                person = person.Where(s => s.Name.Contains(searchString));

            }
          
            person = person.OrderBy(s => s.Name);
            int pageSize = 1;
            int pageNumber = (page ?? 1);


            return View(person.ToPagedList(pageNumber, pageSize));



        }


        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            string[] ids = formCollection["personID"].Split(new char[]{','});
            foreach (string id in ids)
            {
                var person = this.db.Persons.Find(int.Parse(id));
                this.db.Persons.Remove(person);
                this.db.SaveChanges();
                TempData["message"] = string.Format("Usunięto ");
            }
            return RedirectToAction("Index");
        }




        public ViewResult Index2()
        {
            return View(repository.Persons);
        }


        public ViewResult Edit(int? personID)
        {

            Person person = repository.Persons.FirstOrDefault(p => p.personID == personID);
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

      

        public ActionResult Details(int? personID)
        {

            Person person = repository.Persons.FirstOrDefault(p => p.personID == personID);
            return View(person);
        }


        [HttpPost]
        public ActionResult Delete(int personID)
        {
            Person delPerson = repository.DeletePerson(personID);
            if (delPerson != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", delPerson.Name);
            } return RedirectToAction("Index");
        }

    }
}