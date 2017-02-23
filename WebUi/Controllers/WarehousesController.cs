using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Abstract;
using WebUi.Models;
using PagedList;
using System.Data.Entity;
using Domain.Concrete;

namespace WebUi.Controllers
{
    public class WarehousesController : Controller
    {
        private EFDbContext db = new EFDbContext();

        private IWarehousesRepository repository;
        private IActRepository repository1;

        public int PageSize = 1;
        public WarehousesController(IWarehousesRepository warehousesRepository, IActRepository repo)
        {
            this.repository = warehousesRepository;
            this.repository1 = repo;

        }

        public ViewResult List()
        {
            return View(repository.Warehousess);
        }


        public ViewResult Index(int? SelectedAct, string sortOrder, string currentFilter, string searchString, int? page)
        {

            var act = db.Acts.OrderBy(q => q.Active).ToList();
            ViewBag.SelectedAct = new SelectList(act, "actID", "Active", SelectedAct);
            int cctID = SelectedAct.GetValueOrDefault();

            IQueryable<Warehouses> ware = db.Warehousess
             .Where(c => !SelectedAct.HasValue || c.actID == cctID)
            .OrderBy(d => d.WarehousesID)
            .Include(d => d.Act);


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

            ViewBag.CurrentFilter = searchString;


            if (!String.IsNullOrEmpty(searchString))
            {
                ware = ware.Where(s => s.Name.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    ware = ware.OrderByDescending(s => s.Name);
                    break;

                default:
                    ware = ware.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);


            return View(ware.ToPagedList(pageNumber, pageSize));













///            return View(repository.Warehousess);
        }

        public ViewResult Create()
        {
            Populate();
            return View("Edit", new Warehouses());
        }


        public ActionResult Details(int? WarehousesID)
        {
            Warehouses warehouses = repository.Warehousess.FirstOrDefault(p => p.WarehousesID == WarehousesID);
            return View(warehouses);
        }



        public ViewResult Edit(int? WarehousesID)
        {
            Warehouses warehouses = repository.Warehousess.FirstOrDefault(p => p.WarehousesID == WarehousesID);
            Populate(warehouses.actID);
            return View(warehouses);

        }
        public void Populate(object selectedact = null)
        {
            var trannsportQuery = from d in repository1.Acts
                                  orderby d.Active
                                  select d;
            ViewBag.actID = new SelectList(trannsportQuery, "actID", "Active", selectedact);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Warehouses warehouse)
        {
            if (ModelState.IsValid)
            {
                repository.SaveWarehouses(warehouse);
                TempData["message"] = string.Format("Zapisano {0} ", warehouse.Name);
                return RedirectToAction("Index");
            }
            else
            {
                Populate();
                return View(warehouse);
            }


        }
        public ActionResult Delete(int WarehousesID)
        {
            Warehouses delwarehouse = repository.DeleteWarehouses(WarehousesID);
            if (delwarehouse != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", delwarehouse.Name);
            }
            return RedirectToAction("Index");
        }
    }
}