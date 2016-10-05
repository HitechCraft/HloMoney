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
    using Core.Repository.Specification;
    using Models;
    using Manager;

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
                
                return View(vm);
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
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
                        Image = ImageManager.GetImageBytes(uploadImage)
                    });

                    return RedirectToAction("Index", "Home");
                }
                catch(Exception e)
                {
                    ModelState.AddModelError(String.Empty, e.Message);
                }
            }

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
                        Image = vm.Image
                    });

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(String.Empty, e.Message);
                }
            }

            return View(vm);
        }

        [HttpGet]
        public ActionResult Current()
        {
            try
            {
                var vm = new EntityListQueryHandler<Contest, ContestViewModel>(Container)
                    .Handle(new EntityListQuery<Contest, ContestViewModel>
                    {
                        Projector = Container.Resolve<IProjector<Contest, ContestViewModel>>()
                    }).OrderByDescending(x => x.Id).First();

                return PartialView("_Contest", vm);
            }
            catch (Exception e)
            {
                return PartialView("_Contest");
            }
        }
    }
}