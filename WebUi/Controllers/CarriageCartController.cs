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
    public class CarriageCartController : Controller
    {
        private IPacksRepository repository;

        public CarriageCartController(IPacksRepository repo)
        {
            repository = repo;

        }

        public ViewResult Index(string returnUrl)
        {
            return View(new PacksIndexViewModel
            {
                CarriageCart = GetCart(),
                ReturnUrl = returnUrl
            });


        }

        public RedirectToRouteResult AddtoCart(int? PacksID, string returnUrl)
        {
            Packs pack = repository.Packss.FirstOrDefault(p => p.PacksID == PacksID);
            if (pack != null)
            {
                GetCart().AddPackstoCarriage(pack, 1);

            }
            return RedirectToAction("Index", new { returnUrl });


        }

        public RedirectToRouteResult RemoveFromCart (int? PacksID, string returnUrl)
        {
            Packs pack = repository.Packss.FirstOrDefault(p => p.PacksID == PacksID);
            if (pack != null)
            {
                GetCart().RemoveLine(pack);

            }
            return RedirectToAction("Index", new { returnUrl });



        }

        private CarriageCart GetCart()
        {
            CarriageCart cart = (CarriageCart)Session["CarriageCart"];
            if(cart == null)
            {
                cart = new CarriageCart();
                Session["CarriageCart"] = cart;

            }
            return cart;
        }

    }
}