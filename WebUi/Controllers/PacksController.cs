using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Abstract;
using WebUi.Models;
using System.Net;
using System.Data.Entity.Infrastructure;
using Domain.Concrete;
using System.Data.Entity;
using PagedList;

namespace WebUi.Controllers
{
    public class PacksController : Controller
    {

        private EFDbContext db = new EFDbContext();
        private IPacksRepository repository;
        private IWarehousesRepository repository1;
        private IPersonRepository repository2;
        public int PageSize = 4;
        public PacksController(IPacksRepository packrepostiory,IWarehousesRepository repo,IPersonRepository repo2)
        {
            this.repository = packrepostiory;
            this.repository1 = repo;
            this.repository2 = repo2;
            
        }
        
     

        [HttpGet]
        public ActionResult Index(int? SelectedWarehouses,string sortOrder, string currentFilter1, string currentFilter, string searchString1, string searchString, int? page)
        {

            var warehouse = db.Warehousess.OrderBy(q => q.Name).ToList();
            ViewBag.SelectedWarehouses = new SelectList(warehouse, "WarehousesID", "Name", SelectedWarehouses);
            int warehouseID = SelectedWarehouses.GetValueOrDefault();

            IQueryable<Packs> packs = db.Packss
                 .Where(c => !SelectedWarehouses.HasValue || c.WarehousesID == warehouseID)
                .OrderBy(d => d.PacksID)
                .Include(d => d.Warehouses);

            
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;

            }

            if (searchString1 != null)
            {
                page = 1;
            }
            else
            {
                searchString1 = currentFilter1;

            }
            ViewBag.CurrentFilter1 = searchString1;
            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                packs = packs.Where(s => s.Name.Contains(searchString));

            }

            if (!String.IsNullOrEmpty(searchString1))
            {
                packs = packs.Where(s => s.Person.Name.Contains(searchString));
                                       
            }
            switch (sortOrder)
            {
                case "name_desc":
                    packs = packs.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    packs = packs.OrderBy(s => s.dataprzyjeciadomagazynu);
                    break;
                case "date_desc":
                    packs = packs.OrderByDescending(s => s.dataprzyjeciadomagazynu);
                    break;
                default:  
                    packs = packs.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 1;
            int pageNumber = (page ?? 1);


           return View(packs.ToPagedList(pageNumber, pageSize));

           
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            string[] ids = formCollection["PacksID"].Split(new char[]{','});
            foreach (string id in ids)
            {

                Packs packs = this.db.Packss.Find(int.Parse(id));
                if (packs != null)
                  {
               // var packs = this.db.Packss.Find(int.Parse(id));

                this.db.Packss.Remove(packs);
                    this.db.SaveChanges();
                    TempData["message"] = string.Format("Usunięto ");
               }
            }
            return RedirectToAction("Index");
        }

        public ViewResult Index1()
        {
            return View(repository.Packss);
        }

        public void Populate1(object selectedPerson = null)
        {
            var personQuery = from d in repository2.Persons
                                  orderby d.Name
                                  select d;
            ViewBag.personID = new SelectList(personQuery, "personID", "Name", selectedPerson);

        }


        public void Populate(object selectedWarehouse = null)
        {
            var trannsportQuery = from d in repository1.Warehousess
                                  orderby d.Name
                                  select d;
            ViewBag.WarehousesID = new SelectList(trannsportQuery, "WarehousesID", "Name", selectedWarehouse);

        }
        public ViewResult List(int page = 1)
        {
            PacksListViewModel model = new PacksListViewModel
            {
                Packss = repository.Packss
                    .OrderBy(p => p.PacksID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    PersonsPerPage = PageSize,
                    TotalPersons = repository.Packss.Count()
                }

            };
            return View(model);
        }
       
        public ActionResult Create()
        {
            Populate();
            Populate1();


            return View("Edit", new Packs());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Packs packs)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Packss.Add(packs);
                    db.SaveChanges();
                    repository.SavePacks(packs);
                    
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                
                ModelState.AddModelError("", "Nie udało się zapisać");
            }
            Populate(packs.WarehousesID);
            Populate1(packs.personID);
            return View(packs);



        }






        public ActionResult Details(int? PacksID)
        {
           Packs packs = repository.Packss.FirstOrDefault(p => p.PacksID == PacksID);
           return View(packs);
        }



        public ViewResult Edit(int? PacksID)
        {
            Packs packss = repository.Packss.FirstOrDefault(p => p.PacksID == PacksID);
            Populate(packss.WarehousesID);
            Populate1(packss.personID);

            return View(packss);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Packs packs)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    repository.SavePacks(packs);
                    TempData["message"] = string.Format("Zapisano {0} ", packs.Name);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Nie udało się zapisać");
           

            }
            Populate();
            Populate1();

            return View(packs);

        }
        [HttpPost]
        public ActionResult Delete(int PacksID)
        {
            Packs delpacks = repository.DeletePacks(PacksID);
            if (delpacks != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", delpacks.Name);
            }
            return RedirectToAction("Index");
        }
    }
}