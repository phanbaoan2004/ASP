using PhanBaoAn.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PhanBaoAn.Areas.admin.Controllers
{
    public class UsersController : Controller
    {
        ASPEntities objASPEntities = new ASPEntities();
        // GET: admin/Product
        public ActionResult Index()
        {
            var lstuser = objASPEntities.user.ToArray();
            return View(lstuser);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(user objUser)
        {
            try
            {
                
                objUser.password = CreateMD5(objUser.password);
                objASPEntities.user.Add(objUser);
                objASPEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                ModelState.AddModelError("", "Không thể thêm . Lỗi: " + ex.Message);
                return View(objUser);
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objUser = objASPEntities.user.Where(n => n.userId == id).FirstOrDefault();
            return View(objUser);


        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            // Tìm user theo id
            var objUser = objASPEntities.user.FirstOrDefault(n => n.userId == id);

            // Kiểm tra nếu user không tồn tại
            if (objUser == null)
            {
                return HttpNotFound(); // Trả về lỗi 404 nếu không tìm thấy user
            }

            return View(objUser);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            // Tìm user theo id
            var objUser = objASPEntities.user.FirstOrDefault(n => n.userId == id);

            // Kiểm tra nếu user không tồn tại
            if (objUser == null)
            {
                return HttpNotFound(); // Trả về lỗi 404 nếu không tìm thấy user
            }

            // Xóa user và lưu thay đổi
            objASPEntities.user.Remove(objUser);
            objASPEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objUser = objASPEntities.user.Where(n => n.userId == id).FirstOrDefault();
            return View(objUser);

        }

        [HttpPost]
        public ActionResult Edit(user objUser)
        {
           
            objUser.password =CreateMD5(objUser.password);
            objASPEntities.Entry(objUser).State = EntityState.Modified;
            objASPEntities.SaveChanges();
            return RedirectToAction("Index");

        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                //return Convert.ToHexString(hashBytes); 
                // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                StringBuilder obj = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    obj.Append(hashBytes[i].ToString("X2"));
                }
                return obj.ToString();
            }
        }
    }

}