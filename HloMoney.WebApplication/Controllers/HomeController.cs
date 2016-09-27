using HloMoney.Core.Entity.Base;

namespace HloMoney.WebApplication.Controllers
{
    using System.Web.Mvc;
    using Core.DI;
    using Core.Helper;
    using BL.CQRS.Query.Entity;
    using Core.Entity;
    using Core.Projector;
    using Models;

    public class HomeController : BaseController
    {
        public HomeController(IContainer container) : base(container)
        {
        }
        
        public ActionResult Index()
        {
            var entity =
                new EntityQueryHandler<Contest, ContestViewModel>(this.Container)
                .Handle(new EntityQuery
                    <Contest, ContestViewModel>()
                {
                    Id = 1,
                    Projector = this.Container.Resolve<IProjector<Contest, ContestViewModel>>()
                });

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