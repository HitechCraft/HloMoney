﻿namespace HloMoney.WebApplication.Controllers
{
    #region Using Directives

    using System.Web.Mvc;
    using Core.DI;
    using BL.CQRS.Query.Entity;
    using Core.Entity;
    using Core.Extentions;
    using Core.Projector;
    using Models;

    #endregion

    public class CommentController : BaseController
    {
        public int CommentOnLoad => 10;

        #region Constructors

        public CommentController(IContainer container) : base(container)
        {
        }

        #endregion

        #region CRUD

        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region Actions

        public ActionResult GetCommentList(int? page)
        {
            var current = page ?? 1;

            var vm = new EntityListQueryHandler<Comment, CommentViewModel>(this.Container)
                .Handle(new EntityListQuery<Comment, CommentViewModel>
                {
                    Projector = this.Container.Resolve<IProjector<Comment, CommentViewModel>>()
                })
            .TakeRange((current - 1) * this.CommentOnLoad, current * this.CommentOnLoad);

            return PartialView("_CommentPartialList", vm);
        }

        #endregion
    }
}