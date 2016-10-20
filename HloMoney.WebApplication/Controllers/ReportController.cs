namespace HloMoney.WebApplication.Controllers
{
    #region Using Directives

    using System.Web.Mvc;
    using Core.DI;
    using System;
    using Core.Repository.Specification.User;
    using BL.CQRS.Command;
    using Core.Extentions;
    using BL.CQRS.Query.Entity;
    using Core.Entity;
    using Models;
    using System.Linq;
    using Core.Projector;

    #endregion

    public class ReportController : BaseController
    {
        public int ReportOnLoad => 3;

        public ReportController(IContainer container) : base(container)
        {
        }

        #region CRUD

        // GET: Report
        public ActionResult Index()
        {
            ViewBag.OverallMark = this.GetServiceMark();

            return View();
        }

        // GET: Report
        [Authorize]
        public ActionResult Create()
        {
            if (new EntityExistsQueryHandler<Report>(this.Container)
                .Handle(new EntityExistsQuery<Report>()
                {
                    Specification = new ReportByUserSpec(this.CurrentUser.Id)
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
                    Specification = new ReportByUserSpec(this.CurrentUser.Id)
                }))
            {
                return View("AlreadyReported");
            }

            if (vm.Mark < 1 || vm.Mark > 5) ModelState.AddModelError("Mark", Resource.ErrorReportMarkLength);

            try
            {
                if (ModelState.IsValid)
                {
                    this.CommandExecutor.Execute(new ReportCreateCommand
                    {
                        AuthorId = this.CurrentUser.Id,
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

        [HttpGet]
        public ActionResult GetReportList(int? page)
        {
            var current = page ?? 1;

            var vm = new EntityListQueryHandler<Report, ReportViewModel>(this.Container)
                .Handle(new EntityListQuery<Report, ReportViewModel>
                {
                    Projector = this.Container.Resolve<IProjector<Report, ReportViewModel>>()
                })
            .TakeRange((current - 1) * this.ReportOnLoad, current * this.ReportOnLoad);

            return PartialView("_ReportPartialList", vm);
        }

        [HttpGet]
        [Authorize]
        public bool IsAlreadyReported()
        {
            return new EntityExistsQueryHandler<Report>(this.Container)
                .Handle(new EntityExistsQuery<Report>
                {
                    Specification = new ReportByUserSpec(this.CurrentUser.Id)
                });
        }

        [HttpGet]
        public bool IsAllReportsLoaded(int? index)
        {
            var current = index ?? 1;

            var reportCount = new EntityCountQueryHandler<Report>(this.Container)
                .Handle(new EntityCountQuery<Report>());

            return current * this.ReportOnLoad >= reportCount;
        }

        #endregion

        #region Private Methods

        private float GetServiceMark()
        {
            var marks = new EntityListQueryHandler<Report, float>(this.Container)
                .Handle(new EntityListQuery<Report, float>
                {
                    Projector = new CommonProjector<Report, float>(x => x.Mark)
                });

            if (marks.Any()) return (float)Math.Round(marks.Aggregate((start, next) => start + next) / marks.Count, 1);

            return 0;
        }

        #endregion
    }
}