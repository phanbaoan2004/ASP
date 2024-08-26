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
            objHomemodel.ListCategory = objASPEntities.category.ToList();

            objHomemodel.ListProduct = objASPEntities.product.ToList();

            return View(objHomemodel);
        }
    

       
    }
}