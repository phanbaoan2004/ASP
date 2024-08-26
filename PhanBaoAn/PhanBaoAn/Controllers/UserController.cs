using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PhanBaoAn.Context;

namespace PhanBaoAn.Controllers
{
    
    public class UserController : Controller
    {
        ASPEntities obj = new ASPEntities();
        //GET: User

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user objUser)
        {
            objUser.password = CreateMD5(objUser.password);
            var FlagUser = obj.user.Where(n => n.email == objUser.email && n.password == objUser.password).ToList();
            if (FlagUser.Count > 0)
            {
                Session["username"] = FlagUser.FirstOrDefault().lastname.ToString() + FlagUser.FirstOrDefault().firstname.ToString();
                Session["idUser"] = FlagUser.FirstOrDefault().userId;
            }
            return RedirectToAction("Index", "Home");
        }

        

        public ActionResult Register()
        {
            return View();
 
        }
        [HttpPost]
        public ActionResult Register(user objUser)
        {
            try
            {
                //if (objUser.ImageUpload != null)
                //{
                //    // Lấy tên file không có phần mở rộng
                //    string fileName = Path.GetFileNameWithoutExtension(objUser.ImageUpload.FileName);
                //    // Lấy phần mở rộng
                //    string extension = Path.GetExtension(objUser.ImageUpload.FileName);
                //    // Tạo tên file mới với thời gian hiện tại để tránh trùng tên
                //    fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + extension;
                //    // Đặt đường dẫn lưu file
                //    string path = Path.Combine(Server.MapPath("~/Content/images/items/"), fileName);
                //    // Lưu file vào thư mục
                //    objUser.ImageUpload.SaveAs(path);
                //    // Lưu tên file vào cơ sở dữ liệu
                //    objUser.image = fileName;
                //}
              
                if (ModelState.IsValid)
                {
                    // Mã hóa mật khẩu bằng MD5
                    objUser.password = CreateMD5(objUser.password);

                    
                }
                // Thêm người dùng vào cơ sở dữ liệu
                obj.user.Add(objUser);
                obj.SaveChanges();

                // Chuyển hướng đến trang đăng nhập sau khi đăng ký thành công
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                Console.WriteLine(ex.Message);
                // Bạn có thể thêm thông báo lỗi vào ModelState để hiển thị thông báo lỗi trên view
                ModelState.AddModelError("", "Đã có lỗi xảy ra. Vui lòng thử lại.");
            }

            return View(objUser);

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
        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
    }
}