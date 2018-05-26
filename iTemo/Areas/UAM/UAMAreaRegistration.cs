using System.Web.Mvc;

namespace iTemo.Areas.UAM
{
    public class UAMAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UAM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UAM_default",
                "UAM/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}