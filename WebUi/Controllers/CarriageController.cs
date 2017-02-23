using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete;
using System.Data.Entity.Infrastructure;
using WebUi.ViewModel;

namespace WebUi.Controllers
{
    public class CarriageController : Controller
    {

        private EFDbContext db = new EFDbContext();
        private ICarriageRepository repository;
        private IWarehousesRepository repository1;
        private ITransportfleetRepository repository2;
        private IPacksRepository repository3;
        public CarriageController(ICarriageRepository repo, IWarehousesRepository repo1, ITransportfleetRepository repo2, IPacksRepository repo3)
        {
            repository = repo;
            repository1 = repo1;
            repository2 = repo2;
            repository3 = repo3;
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
            Populate(carriage.WarehousesID);
         //   Populate1(carriage.TranID);

            return View(carriage);

        }
        private void PopulatePacks(Carriage carriage)
        {
            var allpacks = db.Packss;
            
            var carriagePacks = new HashSet<int>(carriage.Packss.Select(c => c.PacksID));
            var viewModel = new List<AssignedPacksData>();
            foreach(var pack in allpacks)
            {
                viewModel.Add(new AssignedPacksData
                {
                    PacksID = pack.PacksID,
                    Name = pack.Name,
                    Assigned = carriagePacks.Contains(pack.PacksID) 
                
                });

                }
            ViewBag.Packs = viewModel;


        }
        public void Populate(object selectedWarehouse = null)
        {
            var trannsportQuery = from d in repository1.Warehousess
                                  orderby d.Name
                                  select d;
            ViewBag.WarehousesID = new SelectList(trannsportQuery, "WarehousesID", "Name", selectedWarehouse);

        }

        public void Populate1(object selectedWarehouse = null)
        {
            var trannsportQuery = from d in repository2.Transportfleets
                                  orderby d.Carname
                                  select d;
            ViewBag.TranID = new SelectList(trannsportQuery, "TranID", "Carname", selectedWarehouse);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Carriage carriage, string[] selectedPacks)
        {

            try
            {
                if (selectedPacks != null)
                {
                    carriage.Packss = new List<Packs>();
                    foreach(var pack in selectedPacks)
                    {
                        var packstoAdd = db.Packss.Find(int.Parse(pack));
                        carriage.Packss.Add(packstoAdd);

                    }

                }


                //carriage.Packss = new List<Packs>();
                if (ModelState.IsValid)
                {
                    repository.SaveCarriage(carriage);
                    TempData["message"] = string.Format("Zapisano {0} ", carriage.Target);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Nie udało się zapisać");


            }
            PopulatePacks(carriage);
            Populate();
            Populate1();

            return View(carriage);






        }
        public ViewResult Create()
        {
            Populate();
            Populate1();
            var carriage = new Carriage();
            carriage.Packss = new List<Packs>();
            PopulatePacks(carriage);
            return View("Edit", new Carriage());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carriage carriage)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    db.Carriagess.Add(carriage);
                    db.SaveChanges();
                    repository.SaveCarriage(carriage);

                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {

                ModelState.AddModelError("", "Nie udało się zapisać");
            }
            Populate(carriage.WarehousesID);
          //  Populate1(carriage.TranID);
            return View(carriage);



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
                TempData["message"] = string.Format("Usunięto {0}", delCar.Target);
            }
            return RedirectToAction("Index");
        }

     /*   private Carriage GetCart()
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
        }*/
    }
}