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
    public class PacksController : Controller
    {
        private IPacksRepository repository;
        //private IWarehousesRepository repository1;
        public int PageSize = 4;
        public PacksController(IPacksRepository packrepostiory)
        {
            this.repository = packrepostiory;
            
        }
        
     

        
        public ViewResult Index()
        {
            return View(repository.Packss);
        }
        public ViewResult Index1()
        {
            return View(repository.Packss);
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

        public ViewResult Create()
        {
         
                          
            return View("Edit", new Packs());
        }
        public ActionResult Details(int? PacksID)
        {
           Packs packs = repository.Packss.FirstOrDefault(p => p.PacksID == PacksID);
           return View(packs);
        }



        public ViewResult Edit(int? PacksID)
        {
            Packs packss = repository.Packss.FirstOrDefault(p => p.PacksID == PacksID);
            
            return View(packss);
            
        }

        [HttpPost]
        public ActionResult Edit(Packs packs)
        {
            if (ModelState.IsValid)
            {
                repository.SavePacks(packs);
                TempData["message"] = string.Format("Zapisano {0} ", packs.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(packs);

            }

        }
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