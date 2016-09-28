using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HloMoney.BL.CQRS.Query.Entity;
using HloMoney.Core.DI;
using HloMoney.Core.Entity;
using HloMoney.Core.Helper;
using HloMoney.Core.Projector;
using HloMoney.WebApplication.Models;

namespace HloMoney.WebApplication.Controllers
{
    public class ContestController : BaseController
    {
        public ContestController(IContainer container) : base(container)
        {
        }

        // GET: Contest
        public ActionResult Details(int? id)
        {
            try
            {
                var vm = new EntityQueryHandler<Contest, ContestViewModel>(this.Container)
                    .Handle(new EntityQuery<Contest, ContestViewModel>()
                    {
                        Id = id,
                        Projector = this.Container.Resolve<IProjector<Contest, ContestViewModel>>()
                    });

                ViewBag.Members = VkApiHelper.GetUserInfo("354747, 3345662 , 5367774, 2546432").response;

                return View(vm);
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }
    }
}