using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete;
using System.Data;
using System.Data.Entity;

using System.Data.Entity.Infrastructure;
using WebUi.ViewModel;
using System.Net;
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
        public ActionResult Index()
        {
            var viewModel = new CarriageIndexData();

            viewModel.Carriagess = db.Carriagess
                  .Include(i => i.Packss);
                   
           // var viewmodel = db.Carriagess.Include(p => p.Packss);

           

          /*  if (id != null)
            {
                ViewBag.CarriageID = id.Value;
                viewModel.Packss = viewModel.Carriagess.Where(i => i.CarriageID == id.Value).Single().Packss;
            }
           /* if (packsID != null)
            {
                ViewBag.PacksID = packsID.Value;
                // Lazy loading
                //viewModel.Enrollments = viewModel.Courses.Where(
                //    x => x.CourseID == courseID).Single().Enrollments;
                // Explicit loading
                var selectedCourse = viewModel.Packss.Where(x => x.PacksID == packsID).Single();
                
                
              
            }*/

            
            return View(viewModel);




        }





        public ViewResult Edit(int? CarriageID)
        {
            Carriage carriage = repository.Carriagess.FirstOrDefault(p => p.CarriageID == CarriageID);
            Populate(carriage.WarehousesID);
            //   Populate1(carriage.TranID);
            PopulatePacks(carriage);
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
            ViewBag.Packss = viewModel;


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

         
             PopulatePacks(carriage);
             Populate();
             Populate1();

            return View(carriage);






        }
        public ActionResult Create()
        {
            Populate();
            Populate1();
            var carriage = new Carriage();
            carriage.Packss = new List<Packs>();
            PopulatePacks(carriage);
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carriage carriage, string[] selectedPacks)
        {

            
            if (selectedPacks != null)
            {
                carriage.Packss = new List<Packs>();
                foreach (var pack in selectedPacks)
                {
                    var packstoAdd = db.Packss.Find(int.Parse(pack));
                    carriage.Packss.Add(packstoAdd);

                }

            }

            if (!ModelState.IsValid)
            {
                return View(carriage);
            }

            //carriage.Packss = new List<Packs>();
            if (ModelState.IsValid)
            {
                db.Carriagess.Add(carriage);
                db.SaveChanges();
                //repository.SaveCarriage(carriage);

                // repository.SaveCarriage(carriage);
                //   TempData["message"] = string.Format("Zapisano {0} ", carriage.Target);
                return RedirectToAction("Index");
            }

           
           // PopulatePacks(carriage);
            Populate(carriage.WarehousesID);
            Populate1(carriage.TranID);
           PopulatePacks(carriage);

            /*   if (ModelState.IsValid)
               {
                   db.Carriagess.Add(carriage);
                   db.SaveChanges();
                   return RedirectToAction("Index");
               }
              PopulatePacks(carriage);
              Populate(carriage.WarehousesID);
              Populate1(carriage.TranID);
              */
            
            return View();






        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Details(int? id)
        {

            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carriage carriage = db.Carriagess.Find(id);
            if (carriage == null)
            {
                return HttpNotFound();
            }

            return View();
        }


        /*
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
            catch (RetryLimitExceededException /* dex *///)
        /*    {

                ModelState.AddModelError("", "Nie udało się zapisać");
            }
            Populate(carriage.WarehousesID);
          //  Populate1(carriage.TranID);
            return View(carriage);



        }*







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