using PhanBaoAn.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanBaoAn.Areas.admin.Controllers
{
    public class OrderController : Controller
    {
        ASPEntities objASPEntities = new ASPEntities();
        // GET: admin/Product
        public ActionResult Index()
        {
            var lstorder = objASPEntities.order.ToArray();
            return View(lstorder);
        }
      

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objOrder = objASPEntities.order.Where(n => n.id == id).FirstOrDefault();
            return View(objOrder);


        }

    }


}