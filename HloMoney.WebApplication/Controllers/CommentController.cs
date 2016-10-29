using System.Linq;
using HloMoney.BL.CQRS.Command;
using HloMoney.BL.CQRS.Query;
using HloMoney.Core.Models.Enum;
using HloMoney.Core.Repository.Specification;
using HloMoney.WebApplication.Mapper;

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
        public int CommentOnLoad => 3;

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
                    AuthorId = this.CurrentUser.Id,
                    Text = text,
                    ContestId = contestId
                });

                return Json(new { status = "OK", message = "Успешно" });
            }
            catch (Exception e)
            {
                return Json(new { status = "NO", message = "Ошибка добавления: " + e.Message });
            }
        }

        #endregion

        #region Actions

        [HttpGet]
        public bool IsAllCommentsLoaded(int? index, int contestId)
        {
            var current = index ?? 1;

            var reportCount = new EntityCountQueryHandler<Comment>(this.Container)
                .Handle(new EntityCountQuery<Comment>
                {
                    Specification = new CommentByContestSpec(contestId)
                });

            return current * this.CommentOnLoad >= reportCount;
        }

        public ActionResult GetCommentPartial(int contestId)
        {
            ViewBag.IsCommentType = new EntityQueryHandler<Contest, bool>(this.Container)
                   .Handle(new EntityQuery<Contest, bool>
                   {
                       Id = contestId,
                       Projector = new CommonProjector<Contest, bool>(x => x.Type == ContestType.CommentTime)
                   });

            return PartialView("_CommentPartial", new EntityQueryHandler<Contest, ContestViewModel>(this.Container)
                .Handle(new EntityQuery<Contest, ContestViewModel>
                {
                    Id = contestId,
                    Projector = this.Container.Resolve<IProjector<Contest, ContestViewModel>>()
                }));
        }

        public ActionResult GetCommentList(int? page, int contestId)
        {
            var current = page ?? 1;

            var vm = new EntityListQueryHandler<Comment, CommentViewModel>(this.Container)
                .Handle(new EntityListQuery<Comment, CommentViewModel>
                {
                    Specification = new CommentByContestSpec(contestId),
                    Projector = this.Container.Resolve<IProjector<Comment, CommentViewModel>>()
                })
                .OrderByDescending(x => x.Id)
                .TakeRange((current - 1) * this.CommentOnLoad, current * this.CommentOnLoad)
                .ToList();

            //Comments is sort descending. That last is first
            ViewBag.FirstComment = (vm.Any() ? vm.Last().Id : 0);
            ViewBag.LastComment = (vm.Any() ? vm.First().Id : 0);
            
            return PartialView("_CommentPartialList", vm);
        }
        
        public ActionResult GetNewCommentList(int contestId, int lastCommentId)
        {
            if (lastCommentId != 0)
            {
                var vm = new CommentNewQueryHandler<Comment, CommentViewModel>(this.Container)
                .Handle(new CommentNewQuery<Comment, CommentViewModel>
                {
                    LastCommentId = lastCommentId,
                    Specification = new CommentByContestSpec(contestId),
                    Projector = this.Container.Resolve<IProjector<Comment, CommentViewModel>>()
                });

                ViewBag.LastComment = (vm.Any() ? vm.Last().Id : 0);

                return PartialView("_CommentPartialList", vm);
            }

            return null;
        }

        public ActionResult GetOldCommentList(int contestId, int lastCommentId)
        {
            if (lastCommentId != 0)
            {
                var vm = new CommentOldQueryHandler<Comment, CommentViewModel>(this.Container)
                .Handle(new CommentOldQuery<Comment, CommentViewModel>
                {
                    LastCommentId = lastCommentId,
                    Specification = new CommentByContestSpec(contestId),
                    Projector = this.Container.Resolve<IProjector<Comment, CommentViewModel>>()
                });
                
                return PartialView("_CommentPartialList", vm);
            }

            return null;
        }

        public int GetCommentCount(int contestId)
        {
            return new EntityCountQueryHandler<Comment>(this.Container)
                .Handle(new EntityCountQuery<Comment>
                {
                    Specification = new CommentByContestSpec(contestId)
                });
        }

        #endregion
    }
}