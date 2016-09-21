namespace HloMoney.WebApplication.Controllers
{
    using System.Web.Mvc;
    using Core.DI;
    using Core.Helper;
    using Core.Models.Json;
    using Models;
    using System.Linq;

    public class HomeController : BaseController
    {
        public HomeController(IContainer container) : base(container)
        {
        }

        [Authorize]
        public ActionResult Index()
        {
            var test = this.UserInfo;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}