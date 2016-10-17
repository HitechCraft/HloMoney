using HloMoney.Core.Extentions;
using HloMoney.Core.Repository.Specification;
using HloMoney.Core.Repository.Specification.User;
using WebGrease.Css.Extensions;

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
    using Core.Projector;
    using Models;
    using Manager;
    using System.Collections.Generic;
    using Core.Models.Enum;

    #endregion

    public class ContestController : BaseController
    {
        #region Properties

        public int ContestsOnPage => 3;

        #endregion

        #region Constructors

        public ContestController(IContainer container) : base(container)
        {
        }

        #endregion

        #region CRUD

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.Types = this.GetTypeList();

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateInput(false)]
        public ActionResult Create(ContestEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var uploadImage = Request.Files["uploadContestImage"];

                    this.CommandExecutor.Execute(new ContestCreateCommand
                    {
                        Description = vm.Description,
                        Gift = vm.Gift,
                        Image = ImageManager.GetImageBytes(uploadImage),
                        WinnerCount = vm.WinnerCount,
                        Type = vm.Type,
                        EndTime = vm.EndTime
                    });

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(String.Empty, e.Message);
                }
            }

            ViewBag.Types = this.GetTypeList();

            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            try
            {
                var vm = new EntityQueryHandler<Contest, ContestEditViewModel>(this.Container)
                    .Handle(new EntityQuery<Contest, ContestEditViewModel>
                    {
                        Id = id,
                        Projector = this.Container.Resolve<IProjector<Contest, ContestEditViewModel>>()
                    });

                ViewBag.Types = this.GetTypeList();

                return View(vm);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateInput(false)]
        public ActionResult Edit(ContestEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var uploadImage = Request.Files["uploadContestImage"];

                    if (uploadImage != null && uploadImage.ContentLength > 0)
                        vm.Image = ImageManager.GetImageBytes(uploadImage);

                    this.CommandExecutor.Execute(new ContestUpdateCommand
                    {
                        Id = vm.Id,
                        Description = vm.Description,
                        Gift = vm.Gift,
                        Image = vm.Image,
                        WinnerCount = vm.WinnerCount,
                        EndTime = vm.EndTime
                    });

                    return RedirectToAction("Details", new { id = vm.Id });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(String.Empty, e.Message);
                }
            }

            ViewBag.Types = this.GetTypeList();

            return View(vm);
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

                switch (vm.Type)
                {
                    case ContestType.CommentTime:
                        return View("CommentDetails", vm);
                    case ContestType.Global:
                        return View("GlobalDetails", vm);
                    default:
                        return View(vm);
                }
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public JsonResult Delete(int? id)
        {
            try
            {
                this.CommandExecutor.Execute(new ContestRemoveCommand
                {
                    Id = id.Value
                });

                return Json(new { status = "OK", message = "Успешно удалено" });
            }
            catch (Exception e)
            {
                return Json(new { status = "NO", message = "Ошибка удаления: " + e.Message });
            }
        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult ActiveContests(bool? all)
        {
            try
            {
                ViewBag.AllShowed = all != null && all.Value;

                var vm = new EntityListQueryHandler<Contest, ContestViewModel>(Container)
                        .Handle(new EntityListQuery<Contest, ContestViewModel>
                        {
                            Specification = new ContestIsActiveSpec() & !new ContestIsGlobalSpec(),
                            Projector = Container.Resolve<IProjector<Contest, ContestViewModel>>()
                        });

                if (vm.Count <= this.ContestsOnPage) ViewBag.AllShowed = true;

                return PartialView("_ActiveContest", (all != null && all.Value ? vm : vm.Limit(3)));
            }
            catch (Exception e)
            {
                return PartialView("_ActiveContest");
            }
        }

        [HttpGet]
        public ActionResult EndedContests()
        {
            try
            {
                var vm = new EntityListQueryHandler<Contest, ContestViewModel>(Container)
                        .Handle(new EntityListQuery<Contest, ContestViewModel>
                        {
                            Specification = !new ContestIsActiveSpec() & !new ContestIsGlobalSpec(),
                            Projector = Container.Resolve<IProjector<Contest, ContestViewModel>>()
                        });
                
                return PartialView("_EndedContest", vm.Limit(this.ContestsOnPage));
            }
            catch (Exception e)
            {
                return PartialView("_EndedContest");
            }
        }

        [HttpGet]
        public ActionResult ContestMembers(int contestId)
        {
            try
            {
                var vm = new EntityListQueryHandler<ContestPart, ContestPartViewModel>(Container)
                        .Handle(new EntityListQuery<ContestPart, ContestPartViewModel>
                        {
                            Specification = new ContestPartByContestSpec(contestId),
                            Projector = Container.Resolve<IProjector<ContestPart, ContestPartViewModel>>()
                        }).ToList().Randomize();

                ViewBag.MemberCount = vm.Count();

                return PartialView("_ContestMembers", vm.Limit(3));
            }
            catch (Exception e)
            {
                return PartialView("_ContestMembers");
            }
        }

        [HttpGet]
        public ActionResult GlobalContest()
        {
            try
            {
                var vm = new EntityListQueryHandler<Contest, ContestViewModel>(Container)
                    .Handle(new EntityListQuery<Contest, ContestViewModel>
                    {
                        Specification = new ContestIsGlobalSpec(),
                        Projector = Container.Resolve<IProjector<Contest, ContestViewModel>>()
                    }).First();

                return PartialView("_GlobalContest", vm);
            }
            catch (Exception e)
            {
                return PartialView("_GlobalContest");
            }
        }

        private IEnumerable<SelectListItem> GetTypeList()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = Resource.ContestTypeStandart,
                    Value = ((int)ContestType.Standart).ToString(),
                    Selected = false
                },
                new SelectListItem()
                {
                    Text = Resource.ContestTypeStandartTime,
                    Value = ((int)ContestType.StandartTime).ToString(),
                    Selected = true
                },
                new SelectListItem()
                {
                    Text = Resource.ContestTypeCommentTime,
                    Value = ((int)ContestType.CommentTime).ToString()
                },
                new SelectListItem()
                {
                    Text = Resource.ContestTypeGlobal,
                    Value = ((int)ContestType.Global).ToString()
                }
            };
        }

        #endregion
    }
}