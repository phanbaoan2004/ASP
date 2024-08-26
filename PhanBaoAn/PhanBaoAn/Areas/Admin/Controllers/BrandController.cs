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
    public class BrandController : Controller
    {
        ASPEntities objASPEntities = new ASPEntities();
        // GET: admin/Brand
        public ActionResult Index()
        {
            var lstbrand = objASPEntities.brand.ToArray();
            return View(lstbrand);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(brand objCategory)
        {
            try
            {
                if (objCategory.ImageUpload != null)
                {
                    // Lấy tên file không có phần mở rộng
                    string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                    // Lấy phần mở rộng
                    string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                    // Tạo tên file mới với thời gian hiện tại để tránh trùng tên
                    fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + extension;
                    // Đặt đường dẫn lưu file
                    string path = Path.Combine(Server.MapPath("~/Content/images/items/"), fileName);
                    // Lưu file vào thư mục
                    objCategory.ImageUpload.SaveAs(path);
                    // Lưu tên file vào cơ sở dữ liệu
                    objCategory.image = fileName;
                }
                objASPEntities.brand.Add(objCategory);
                objASPEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                ModelState.AddModelError("", "Không thể thêm danh muc. Lỗi: " + ex.Message);
                return View(objCategory);
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objCategory = objASPEntities.brand.Where(n => n.id == id).FirstOrDefault();
            return View(objCategory);


        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objCategory = objASPEntities.brand.Where(n => n.id == id).FirstOrDefault();
            return View(objCategory);

        }

        [HttpPost]
        public ActionResult Delete(brand objBrand)
        {
            var objCategory = objASPEntities.brand.Where(n => n.id == objBrand.id).FirstOrDefault();
            objASPEntities.brand.Remove(objCategory); objASPEntities.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objCategory = objASPEntities.brand.Where(n => n.id == id).FirstOrDefault();
            return View(objCategory);

        }

        [HttpPost]
        public ActionResult Edit(brand objCategory)
        {
            if (objCategory.ImageUpload != null)
            {
                // Lấy tên file không có phần mở rộng
                string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                // Lấy phần mở rộng
                string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                // Tạo tên file mới với thời gian hiện tại để tránh trùng tên
                fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + extension;
                // Đặt đường dẫn lưu file
                string path = Path.Combine(Server.MapPath("~/Content/images/items/"), fileName);
                // Lưu file vào thư mục
                objCategory.ImageUpload.SaveAs(path);
                // Lưu tên file vào cơ sở dữ liệu
                objCategory.image = fileName;
            }
            objASPEntities.Entry(objCategory).State = EntityState.Modified;
            objASPEntities.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}