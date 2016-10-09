namespace HloMoney.WebApplication.Controllers
{
    using System.Web.Mvc;
    using Core.DI;

    public class HomeController : BaseController
    {
        public HomeController(IContainer container) : base(container)
        {
        }

        public ActionResult Title()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Faq()
        {
            return View();
        }

        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}