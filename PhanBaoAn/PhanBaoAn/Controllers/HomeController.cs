using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PhanBaoAn.Context;
using PhanBaoAn.Models;


namespace PhanBaoAn.Controllers
{
    public class HomeController : Controller
    {
        ASPEntities objASPEntities = new ASPEntities();
        public ActionResult Index()
        {
            HomeModel objHomemodel = new HomeModel();
            objHomemodel.ListCategory = objASPEntities.categories.ToList();

            objHomemodel.ListProduct = objASPEntities.products.ToList();

            return View(objHomemodel);
        }
    

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}