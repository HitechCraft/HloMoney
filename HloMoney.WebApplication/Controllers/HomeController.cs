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
        
        public ActionResult Index()
        {
            ViewBag.Members = VkApiHelper.GetUserInfo("354747, 3345662 , 5367774, 2546432").response;

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