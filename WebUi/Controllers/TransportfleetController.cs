using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Abstract;
using Domain.Concrete;
using PagedList;
using System.Data.Entity.Infrastructure;
using WebUi.Models;
using System.Data.Entity;

namespace WebUi.Controllers
{
    public class TransportfleetController : Controller
    {
        private EFDbContext db = new EFDbContext();

        private ITransportfleetRepository repository;
        private IActRepository repository1;
        public int PageSize = 1;
        public TransportfleetController(ITransportfleetRepository transportfleetRepository, IActRepository repo)
        {
            this.repository = transportfleetRepository;
            this.repository1 = repo;
        }

        public ViewResult List()
        {
            return View(repository.Transportfleets);
        }

        [HttpGet]
        public ViewResult Index(int? SelectedAct,string sortOrder, string currentFilter, string searchString, int? page)
        {
            var act = db.Acts.OrderBy(q => q.Active).ToList();
            ViewBag.SelectedAct = new SelectList(act, "actID", "Active", SelectedAct);
            int cctID = SelectedAct.GetValueOrDefault();

            IQueryable<Transportfleet> tran = db.Transportfleets
             .Where(c => !SelectedAct.HasValue || c.actID == cctID)
            .OrderBy(d => d.TranID)
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
                tran = tran.Where(s => s.Carname.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    tran = tran.OrderByDescending(s => s.Carname);
                    break;

                default:
                    tran = tran.OrderBy(s => s.Carname);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);


            return View(tran.ToPagedList(pageNumber, pageSize));
        //    return View(repository.Transportfleets);
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            string[] ids = formCollection["TranID"].Split(new char[]{','});
            foreach (string id in ids)
            {
                var transport = this.db.Transportfleets.Find(int.Parse(id));
               // if (transport != null)
               // {
                    this.db.Transportfleets.Remove(transport);
                    this.db.SaveChanges();
                    TempData["message"] = string.Format("Usunięto ");
             //   }
            }
            return RedirectToAction("Index");
        }


        public ViewResult Create()
        {
            Populate();
            return View("Edit", new Transportfleet());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transportfleet transportfleet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Transportfleets.Add(transportfleet);
                    db.SaveChanges();
                    repository.SaveTransportfleet(transportfleet);

                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {

                ModelState.AddModelError("", "Nie udało się zapisać");
            }
            Populate(transportfleet.actID);
            return View(transportfleet);



        }

        public ActionResult Details(int? TranID)
        {
            Transportfleet transportfleet = repository.Transportfleets.FirstOrDefault(p => p.TranID == TranID);
            return View(transportfleet);
        }

        public void Populate(object selectedact = null)
        {
            var trannsportQuery = from d in repository1.Acts
                                  orderby d.Active
                                  select d;
            ViewBag.actID = new SelectList(trannsportQuery, "actID", "Active", selectedact);

        }

        public ViewResult Edit(int? TranID)
        {
            Transportfleet transportfleet = repository.Transportfleets.FirstOrDefault(p => p.TranID == TranID);
            Populate(transportfleet.actID);
            return View(transportfleet);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transportfleet transportfleet)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    repository.SaveTransportfleet(transportfleet);
                    TempData["message"] = string.Format("Zapisano {0} ", transportfleet.Carname);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Nie udało się zapisać");


            }

            Populate();
            return View(transportfleet);
        }

        [HttpPost]
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