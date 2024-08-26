using PhanBaoAn.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanBaoAn.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        ASPEntities objASPEntities = new ASPEntities();
        public ActionResult Index()
        {
            var lstCategory = objASPEntities.category.ToList();
            return View(lstCategory);
        }

        public ActionResult ProductCategory(int id)
        {
            var lstproduct= objASPEntities.product.Where(n=>n.categoryId==id).ToList();
            return View(lstproduct);
        }
    }
}