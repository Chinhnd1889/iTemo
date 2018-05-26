using System.Web.Mvc;

namespace iTemo.Areas.Product
{
    public class ProductAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Product";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Product_detail",
                "san-pham/chi-tiet-san-pham/{id}",
                new { controller = "product", action = "DetailProduct", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Product_create",
                "san-pham/them-san-pham/{id}",
                new { controller = "product", action = "CreateProduct", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Product_custom",
                "san-pham/{action}/{id}",
                new { controller = "product", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Product_default",
                "Product/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}