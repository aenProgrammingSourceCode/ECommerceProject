using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Product()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Products()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Service()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ProductDetails()
        {

            return View();
        }

        public ActionResult Basket()
        {

            return View();
        }
        [Authorize]
        public ActionResult Customer()
        {

            return View();
        }
        public ActionResult TempPractice()
        {

            return View();
        }

        public ActionResult Orders()
        {

            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }
        public ActionResult AdminPayment()
        {
            return View();
        }

        [Authorize(Roles="Customer")]
        public ActionResult DeliveryAddress()
        {
            return View();
        }

        public ActionResult AngularjsIndex()
        {
            return View();
        }

        public ActionResult ProductsAng()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Dashboard2()
        {
            return View();
        }

        public ActionResult RefinementProduct()
        {
            return View();
        }

        
    }
}
