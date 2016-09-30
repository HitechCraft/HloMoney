namespace HloMoney.WebApplication.Controllers
{
    #region Using Directives

    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
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

                var memberIds = this.GetContestMembers(id.Value);

                ViewBag.Members = VkApiHelper.GetUserInfo(String.Join(", ", memberIds)).response;

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
            var memberIds = this.GetContestMembers(id);

            ViewBag.Members = VkApiHelper.GetUserInfo(String.Join(", ", memberIds)).response;

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

                if (vm.EndTime < DateTime.Now && vm.Status == ContestStatus.Started)
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

        [HttpPost]
        [Authorize]
        public JsonResult CheckPart(int id)
        {
            if (!new EntityExistsQueryHandler<ContestPart>(this.Container)
                .Handle(new EntityExistsQuery<ContestPart>
                {
                    Specification =
                        new ContestPartByContestSpec(id) &
                        new ContestPartByUserSpec(this.CurrentUser.Info.Id.ToString())
                }))
            {
                return Json(new { status = "OK" });
            }

            return Json(new { status = "NO" });
        }

        [HttpPost]
        [Authorize]
        public JsonResult TakePart(int id)
        {
            try
            {
                this.CommandExecutor.Execute(new ContestTakePartCommand
                {
                    ContestId = id,
                    UserId = this.CurrentUser.Info.Id.ToString()
                });

                return Json(new { status = "OK", message = "Вы приняли участие!" });
            }
            catch (Exception e)
            {
                return Json(new {status = "NO", message = "Ошибка: " + e.Message});
            }
        }

        #region Private Methods
        
        private ICollection<string> GetContestMembers(int id)
        {
            return new EntityListQueryHandler<ContestPart, string>(this.Container)
                .Handle(new EntityListQuery<ContestPart, string>()
                {
                    Specification = new ContestPartByContestSpec(id),
                    Projector = new CommonProjector<ContestPart, string>(x => x.UserId)
                });
        }

        #endregion
    }
}