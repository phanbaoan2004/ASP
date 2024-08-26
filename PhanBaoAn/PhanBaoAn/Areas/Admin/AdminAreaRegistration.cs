using System.Web.Mvc;

namespace PhanBaoAn.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                 "Admin_default",
                 "Admin/{controller}/{action}/{id}",
                 new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 new[] { "PhanBaoAn.Areas.admin.Controllers" }
             );
        }
    }
}