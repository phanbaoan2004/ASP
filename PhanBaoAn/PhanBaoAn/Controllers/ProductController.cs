using PhanBaoAn.Context;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace PhanBaoAn.Controllers
{
    public class ProductController : Controller
    {
        ASPEntities context = new ASPEntities();

        public ActionResult Index(string searchTerm, int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            var products = from p in context.product
                           select p;

            // Nếu có từ khóa tìm kiếm, lọc danh sách sản phẩm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p => p.name.Contains(searchTerm));
            }

            var lstPro = products.OrderBy(p => p.id).ToPagedList(pageNumber, pageSize);
            return View(lstPro);
        }

        public ActionResult Detail(int id)
        {
            var detail = context.product.Find(id);
            return View(detail);
        }
    }
}
