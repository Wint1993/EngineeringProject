using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;


namespace WebUi.Controllers
{
    public class CarriageController : Controller
    {
        private ICarriageRepository repository;

        public CarriageController(ICarriageRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.Carriagess);
        }

        public ViewResult Index2()
        {
            return View(repository.Carriagess);
        }



        public ViewResult Edit(int? CarriageID)
        {
            Carriage carriage = repository.Carriagess.FirstOrDefault(p => p.CarriageID == CarriageID);
            return View(carriage);

        }

        [HttpPost]
        public ActionResult Edit(Carriage carriage)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCarriage(carriage);
                TempData["message"] = string.Format("Zapisano {0} ", carriage.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(carriage);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Carriage());
        }



        public ActionResult Details(int? CarriageID)
        {

            Carriage carriage = repository.Carriagess.FirstOrDefault(p => p.CarriageID == CarriageID);
            return View(carriage);
        }


        [HttpPost]
        public ActionResult Delete(int CarriageID)
        {
            Carriage delCar = repository.DeleteCarriage(CarriageID);
            if (delCar != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", delCar.Name);
            }
            return RedirectToAction("Index");
        }

        private Carriage GetCart()
        {
            Carriage cart = (Carriage)Session["Carriage"];
            if (cart == null)
            {
                cart = new Carriage();
                Session["Carriage"] = cart;

            }
            return cart;
        }

        public RedirectToRouteResult back(string returnUrl)
        {
            return RedirectToAction("Edit", new { returnUrl });
        }
    }
}