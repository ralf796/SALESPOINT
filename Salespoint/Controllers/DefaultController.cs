using HELPERS;
using System.Web.Mvc;

namespace RESTAURANTE
{
    public class DefaultController : Controller
    {
        [SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}