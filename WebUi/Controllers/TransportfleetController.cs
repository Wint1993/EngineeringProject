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
    public class TransportfleetController : Controller
    {
        private ITransportfleetRepository repository;
        public int PageSize = 1;
        public TransportfleetController(ITransportfleetRepository transportfleetRepository)
        {
            this.repository = transportfleetRepository;
        }

        public ViewResult List()
        {
            return View(repository.Transportfleets);
        }
        public ViewResult Index()
        {
            return View(repository.Transportfleets);
        }

        public ViewResult Create()
        {
            return View("Edit", new Transportfleet());
        }
        public ActionResult Details(int? TranID)
        {
            Transportfleet transportfleet = repository.Transportfleets.FirstOrDefault(p => p.TranID == TranID);
            return View(transportfleet);
        }



        public ViewResult Edit(int? TranID)
        {
            Transportfleet transportfleet = repository.Transportfleets.FirstOrDefault(p => p.TranID == TranID);
            return View(transportfleet);

        }

        [HttpPost]
        public ActionResult Edit(Transportfleet transportfleet)
        {
            if (ModelState.IsValid)
            {
                repository.SaveTransportfleet(transportfleet);
                TempData["message"] = string.Format("Zapisano {0} ", transportfleet.Carname);
                return RedirectToAction("Index");
            }
            else
            {
                return View(transportfleet);
            }


        }
        public ActionResult Delete(int TranID)
        {
            Transportfleet deltransportfleet = repository.DeleteTransportfleet(TranID);
            if (deltransportfleet != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", deltransportfleet.Carname);
            }
            return RedirectToAction("Index");
        }
    }
}