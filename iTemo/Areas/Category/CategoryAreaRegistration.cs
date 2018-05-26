using System.Web.Mvc;

namespace iTemo.Areas.Category
{
    public class CategoryAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Category";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Category_detail",
                "danh-muc/chi-tiet-danh-muc/{id}",
                new { controller = "category", action = "DetailCategory", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Category_create",
                "danh-muc/them-danh-muc/{id}",
                new { controller = "category", action = "CreateCategory", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Category_custom",
                "danh-muc/{action}/{id}",
                new { controller = "category", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Category_default",
                "Category/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}