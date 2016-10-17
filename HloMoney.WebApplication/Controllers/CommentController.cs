using System.Linq;
using HloMoney.BL.CQRS.Command;

namespace HloMoney.WebApplication.Controllers
{
    #region Using Directives

    using System.Web.Mvc;
    using Core.DI;
    using BL.CQRS.Query.Entity;
    using Core.Entity;
    using Core.Extentions;
    using Core.Projector;
    using Models;
    using System;

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

        public JsonResult Create(string text, int contestId)
        {
            try
            {
                if (text.Length <= 0) throw new Exception("Комментарий не может быть пустым");
                if (text.Length > 255) throw new Exception("Комментарий не может превышать 255 символов");

                this.CommandExecutor.Execute(new CommentCreateCommand
                {
                    AuthorId = this.CurrentUser.Info.Id,
                    Text = text,
                    ContestId = contestId
                });

                return Json(new {status = "OK", message = "Успешно"});
            }
            catch (Exception e)
            {
                return Json(new { status = "NO", message = "Ошибка добавления: " + e.Message });
            }
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

            return PartialView("_CommentPartialList", vm.OrderByDescending(x => x.Date));
        }

        #endregion
    }
}