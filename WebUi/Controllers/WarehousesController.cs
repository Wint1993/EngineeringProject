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
    public class WarehousesController : Controller
    {
        private IWarehousesRepository repository;
        public int PageSize = 1;
        public WarehousesController(IWarehousesRepository warehousesRepository)
        {
            this.repository = warehousesRepository;
            
        }
        
        public ViewResult List()
        {
            return View(repository.Warehousess);
        }
        public ViewResult Index()
        {
            return View(repository.Warehousess);
        }

        public ViewResult Create()
        {
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
            return View(warehouses);

        }

        [HttpPost]
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