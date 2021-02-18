using System.Web.Mvc;

namespace WebApplication1c.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult GetUserInfo(FormCollection collection)
        {
            string username = collection["k"];
            return Content(username);
        }
    }
}
