using PhanBaoAn.Context;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanBaoAn.Controllers
{
    public class ProductController : Controller
    {
        ASPEntities context=new ASPEntities();
        // GET: Prooduct
        public ActionResult Detail(int id)
        {
            var detail = context.products.Find(id);
            return View(detail);
        }
   

    }
}