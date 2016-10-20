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
    using Core.Extentions;
    using Core.Repository.Specification;
    using Core.Repository.Specification.User;
    using WebGrease.Css.Extensions;

    #endregion

    public class ContestController : BaseController
    {
        #region Properties

        public int ContestsOnPage => 3;

        public int MinParts => 10;

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
            ViewBag.Types = GetTypeList();

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

                    CommandExecutor.Execute(new ContestCreateCommand
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

            ViewBag.Types = GetTypeList();

            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            try
            {
                var vm = new EntityQueryHandler<Contest, ContestEditViewModel>(Container)
                    .Handle(new EntityQuery<Contest, ContestEditViewModel>
                    {
                        Id = id,
                        Projector = Container.Resolve<IProjector<Contest, ContestEditViewModel>>()
                    });

                ViewBag.Types = GetTypeList();

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

                    CommandExecutor.Execute(new ContestUpdateCommand
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

            ViewBag.Types = GetTypeList();

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

                //TODO: маппер не заполняет сущности. Разобраться!
                vm.Winners = new List<WinnerViewModel>();
                vm.Winners.AddRange(new EntityListQueryHandler<ContestWinner, WinnerViewModel>(Container)
                        .Handle(new EntityListQuery<ContestWinner, WinnerViewModel>
                        {
                            Specification = new ContestWinnerSpec(vm.Id),
                            Projector = Container.Resolve<IProjector<ContestWinner, WinnerViewModel>>()
                        }));

                if (!CheckContestActivity(vm.Id)) return RedirectToAction("Details", id);

                if (vm.Status == ContestStatus.Ended)
                {
                    ViewBag.WinnersError = GetWinnersError(vm.Id);
                    return View("EndedDetails", vm);
                }
                
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

        private string GetWinnersError(int contestId)
        {
            var partsCount = new EntityCountQueryHandler<ContestPart>(Container)
                .Handle(new EntityCountQuery<ContestPart>
                {
                    Specification = new ContestPartByContestSpec(contestId)
                });

            if (partsCount < this.MinParts)
            {
                return "Минимальное кол-во участников " + this.MinParts + " (приняло участие всего " + partsCount + ")";
            }

            return null;
        }

        [HttpPost]
        public JsonResult Delete(int? id)
        {
            try
            {
                CommandExecutor.Execute(new ContestRemoveCommand
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

                if (vm.Count <= ContestsOnPage) ViewBag.AllShowed = true;

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

                //TODO: маппер не заполняет сущности. Разобраться!
                vm.ForEach(x => x.Winners.Clear());
                vm.ForEach(x => x.Winners.AddRange(new EntityListQueryHandler<ContestWinner, WinnerViewModel>(Container)
                        .Handle(new EntityListQuery<ContestWinner, WinnerViewModel>
                        {
                            Specification = new ContestWinnerSpec(x.Id),
                            Projector = Container.Resolve<IProjector<ContestWinner, WinnerViewModel>>()
                        })));

                return PartialView("_EndedContest", vm.Limit(ContestsOnPage));
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
        
        public bool CheckContestActivity(int contestId)
        {
            try
            {
                var vm = new EntityQueryHandler<Contest, ContestViewModel>(Container)
                    .Handle(new EntityQuery<Contest, ContestViewModel>
                    {
                        Id = contestId,
                        Projector = Container.Resolve<IProjector<Contest, ContestViewModel>>()
                    });

                if (vm.EndTime < DateTime.Now && vm.Status == ContestStatus.Started)
                {
                    CommandExecutor.Execute(new ContestEndCommand
                    {
                        ContestId = contestId
                    });

                    CommandExecutor.Execute(new ContestSelectWinnersCommand()
                    {
                        ContestId = contestId,
                        WinnerCount = vm.WinnerCount,
                        MinPartCount = this.MinParts
                    });

                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public ActionResult GetContestTime(int id)
        {
            ViewBag.Contest = id;

            ViewBag.Time = new EntityQueryHandler<Contest, DateTime>(Container)
                .Handle(new EntityQuery<Contest, DateTime>
                {
                    Id = id,
                    Projector = new CommonProjector<Contest, DateTime>(x => x.EndTime ?? DateTime.Now)
                });

            return PartialView("_ContestTimeHelper");
        }
        
        [Authorize]
        public JsonResult TakePart(int contestId)
        {
            try
            {
                if (CheckPart(contestId)) throw new Exception("Вы уже приняли участие!");

                CommandExecutor.Execute(new ContestTakePartCommand
                {
                    ContestId = contestId,
                    UserId = CurrentUser.Info.Id
                });

                return Json(new { status = "OK", message = "Вы успешно приняли участие! Ожидайте окончания конкурса" });
            }
            catch (Exception e)
            {
                return Json(new { status = "NO", message = "Ошибка: " + e.Message });
            }
        }

        [Authorize]
        public bool CheckCommentPartAvailable(int contestId)
        {
            try
            {
                var comments = new EntityListQueryHandler<Comment, CommentViewModel>(Container)
                        .Handle(new EntityListQuery<Comment, CommentViewModel>
                        {
                            Specification = new CommentByContestSpec(contestId),
                            Projector = this.Container.Resolve<IProjector<Comment, CommentViewModel>>()
                        });

                return comments.Last().AuthorName ==
                       $"{this.CurrentUser.Info.FirstName} {this.CurrentUser.Info.LastName}";
            }
            catch (Exception)
            {
                return false;
            }
        }

        [Authorize]
        public bool CheckPart(int contestId)
        {
            return new EntityExistsQueryHandler<ContestPart>(Container)
                .Handle(new EntityExistsQuery<ContestPart>
                {
                    Specification = new ContestPartByContestSpec(contestId) & new ContestPartByUserSpec(CurrentUser.Info.Id)
                });
        }

        public ActionResult ContestCommentPartChecker(int contestId)
        {
            return PartialView("_CommentPartCheckPartial", contestId);
        }

        private IEnumerable<SelectListItem> GetTypeList()
        {
            return new List<SelectListItem>()
            {
                //TODO: в будущем возможно вернуть этот тип. Пока смысла в нем особого нет
                //new SelectListItem()
                //{
                //    Text = Resource.ContestTypeStandart,
                //    Value = ((int)ContestType.Standart).ToString(),
                //    Selected = false
                //},
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