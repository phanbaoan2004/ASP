using PhanBaoAn.Context;
using PhanBaoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanBaoAn.Controllers
{
    public class PaymentController : Controller
    {
        ASPEntities objASPEntities = new ASPEntities();
        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {

                //lấy thông từ giỏ hàng từ biến session
                var lstcart = (List<CartModel>)Session["cart"];
                //gán dữ liệu cho Order
                order objOrder = new order();
                objOrder.name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.userid = int.Parse(Session["idUser"].ToString());

                objOrder.createdOnUtc = DateTime.Now;
                objOrder.status = 1;
                objASPEntities.order.Add(objOrder);
                //lưu thông tin dữ liệu vào bảng order 
                objASPEntities.SaveChanges();
                //Lấy OrderId vừa mới tạo để lưu vào bảng OrderDetail.
                int intOrderId = objOrder.id;
                List<orderDetail> lstOrderDetail = new List<orderDetail>();
                foreach (var item in lstcart)
                {
                    orderDetail obj = new orderDetail();
                    obj.quantity = item.Quantity;
                    obj.orderId = intOrderId;
                    obj.productId = item.Product.id;
                    lstOrderDetail.Add(obj);

                }
                objASPEntities.orderDetail.AddRange(lstOrderDetail);
                objASPEntities.SaveChanges();

            }
                return View();
        }
    }
}