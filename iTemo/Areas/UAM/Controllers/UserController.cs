using System.Web.Mvc;
using iTemo.Business.Interface;

namespace iTemo.Areas.UAM.Controllers
{
    public class UserController : Controller
    {
        #region Private Variables 

        private readonly IUserBusiness _userBusiness;

        #endregion

        #region Constructors

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        #endregion

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Login()
        {
            return View();
        }
    }
}