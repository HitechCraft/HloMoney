using HloMoney.Core.Projector;

namespace HloMoney.WebApplication.Controllers
{
    #region Using Directives

    using System.Web.Mvc;
    using Core.DI;
    using System;
    using HitechCraft.Core.Repository.Specification;
    using BL.CQRS.Command;
    using BL.CQRS.Query.Entity;
    using Core.Entity;
    using Models;

    #endregion

    public class ReportController : BaseController
    {
        public ReportController(IContainer container) : base(container)
        {
        }

        #region CRUD

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        // GET: Report
        [Authorize]
        public ActionResult Create()
        {
            if (new EntityExistsQueryHandler<Report>(this.Container)
                .Handle(new EntityExistsQuery<Report>()
                {
                    Specification = new RulePointByNameSpec(this.CurrentUser.Info.Id)
                }))
            {
                return View("AlreadyReported", new ReportCreateViewModel());
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(ReportCreateViewModel vm)
        {
            if (new EntityExistsQueryHandler<Report>(this.Container)
                .Handle(new EntityExistsQuery<Report>()
                {
                    Specification = new RulePointByNameSpec(this.CurrentUser.Info.Id)
                }))
            {
                return View("AlreadyReported");
            }

            if (vm.Mark < 1 || vm.Mark > 5) ModelState.AddModelError(String.Empty, "Оценка должна быть в интервале от 0 до 5");

            try
            {
                if (ModelState.IsValid)
                {
                    this.CommandExecutor.Execute(new ReportCreateCommand
                    {
                        AuthorId = this.CurrentUser.Info.Id,
                        Title = vm.Title,
                        Text = vm.Text, 
                        Mark = (float)Math.Round(vm.Mark, 2)
                    });

                    return RedirectToAction("Index");
                }

                return View(vm);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, "Ошибка добавления отзыва: " + e.Message);

                return View(vm);
            }
        }

        #endregion

        #region Public Methods

        public ActionResult GetReportList(int? page)
        {
            var vm = new EntityListQueryHandler<Report, ReportViewModel>(this.Container)
                .Handle(new EntityListQuery<Report, ReportViewModel>
                {
                    Projector = this.Container.Resolve<IProjector<Report, ReportViewModel>>()
                });

            return PartialView("_ReportPartialList", vm);
        }

        #endregion
    }
}