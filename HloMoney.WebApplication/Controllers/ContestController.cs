using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HloMoney.BL.CQRS.Command;
using HloMoney.BL.CQRS.Query.Entity;
using HloMoney.Core.DI;
using HloMoney.Core.Entity;
using HloMoney.Core.Helper;
using HloMoney.Core.Models.Enum;
using HloMoney.Core.Projector;
using HloMoney.Core.Repository.Specification;
using HloMoney.WebApplication.Mapper;
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

        [HttpGet]
        public ActionResult Current()
        {
            try
            {
                var vm = new EntityListQueryHandler<Contest, ContestViewModel>(this.Container)
                    .Handle(new EntityListQuery<Contest, ContestViewModel>
                    {
                        Specification = !new ContestIsEndedSpec(),
                        Projector = this.Container.Resolve<IProjector<Contest, ContestViewModel>>()
                    }).First();

                return PartialView("_Contest", vm);
            }
            catch (Exception e)
            {
                return PartialView("_Contest");
            }
        }

        [HttpGet]
        public ActionResult Members(int id)
        {
            ViewBag.Members = VkApiHelper.GetUserInfo("354747, 3345662 , 5367774, 2546432").response;

            return PartialView("_Members");
        }

        [HttpPost]
        public JsonResult CheckAvailable(int id)
        {
            try
            {
                var vm = new EntityQueryHandler<Contest, ContestViewModel>(this.Container)
                    .Handle(new EntityQuery<Contest, ContestViewModel>
                    {
                        Id = id,
                        Projector = this.Container.Resolve<IProjector<Contest, ContestViewModel>>()
                    });

                if (vm.Status == ContestStatus.Actual)
                {
                    this.CommandExecutor.Execute(new ContestSetStatusCommand()
                    {
                        Id = id,
                        Status = ContestStatus.Ended
                    });

                    return Json(new { status = "OK", message = "Конкурс завершен" });
                }
                
                return Json(new { status = "NO", message = "Конкурс еще не завершен!" });
            }
            catch (Exception e)
            {
                return Json(new { status = "NO", message = "Ошибка завершения: " + e.Message });
            }
        }
    }
}