namespace HloMoney.WebApplication.Controllers
{
    #region Using Directives

    using System;
    using System.Linq;
    using System.Web.Mvc;
    using BL.CQRS.Command;
    using BL.CQRS.Query.Entity;
    using Core.DI;
    using Core.Entity;
    using Core.Helper;
    using Core.Models.Enum;
    using Core.Projector;
    using Core.Repository.Specification;
    using Models;

    #endregion

    public class ContestController : BaseController
    {
        public ContestController(IContainer container) : base(container)
        {
        }

        // GET: Contest
        [Authorize]
        public ActionResult Details(int? id)
        {
            try
            {
                var vm = new EntityQueryHandler<Contest, ContestViewModel>(Container)
                    .Handle(new EntityQuery<Contest, ContestViewModel>()
                    {
                        Id = id,
                        Projector = Container.Resolve<IProjector<Contest, ContestViewModel>>()
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
                var vm = new EntityListQueryHandler<Contest, ContestViewModel>(Container)
                    .Handle(new EntityListQuery<Contest, ContestViewModel>
                    {
                        Specification = !new ContestIsEndedSpec(),
                        Projector = Container.Resolve<IProjector<Contest, ContestViewModel>>()
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
            //ViewBag.Members = VkApiHelper.GetUserInfo("354747, 3345662 , 5367774, 2546432").response;

            return PartialView("_Members");
        }

        [HttpPost]
        public JsonResult CheckAvailable(int id)
        {
            try
            {
                var vm = new EntityQueryHandler<Contest, ContestViewModel>(Container)
                    .Handle(new EntityQuery<Contest, ContestViewModel>
                    {
                        Id = id,
                        Projector = Container.Resolve<IProjector<Contest, ContestViewModel>>()
                    });

                if (vm.EndTime < DateTime.Now && vm.Status == ContestStatus.Actual)
                {
                    CommandExecutor.Execute(new ContestSetStatusCommand()
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

        [HttpGet]
        public ActionResult GetLastContests()
        {
            try
            {
                var vm = new EntityListQueryHandler<Contest, ContestViewModel>(Container)
                    .Handle(new EntityListQuery<Contest, ContestViewModel>
                    {
                        Specification = new ContestIsEndedSpec(),
                        Projector = Container.Resolve<IProjector<Contest, ContestViewModel>>()
                    });

                return PartialView("_LastContests", vm);
            }
            catch (Exception)
            {
                return PartialView("_LastContests");
            }
        }
    }
}