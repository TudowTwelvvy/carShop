using System.Web.Mvc;

namespace carShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        //GET: /home/about/{id}
        public ActionResult About(string id)
        {
            ViewBag.Message = "Your application description page." + id;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}