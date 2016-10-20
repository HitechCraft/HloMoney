using HloMoney.Core.Repository.Specification;
using HloMoney.Core.Repository.Specification.User;

namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using Core.Models.Enum;
    using System;

    #endregion

    public class CommentCreateCommandHandler : BaseCommandHandler<CommentCreateCommand>
    {
        public CommentCreateCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(CommentCreateCommand command)
        {
            var commentRep = this.GetRepository<Comment>();
            var contestRep = this.GetRepository<Contest>();
            var contestPartRep = this.GetRepository<ContestPart>();

            var contest = contestRep.GetEntity(command.ContestId);

            commentRep.Add(new Comment
            {
                Text = command.Text,
                Author = command.AuthorId,
                Contest = contest,
                Date = DateTime.Now
            });

            if (contest.Type == ContestType.CommentTime)
            {
                if (
                    !contestPartRep.Exist(new ContestPartByContestSpec(contest.Id) &
                                          new ContestPartByUserSpec(command.AuthorId)))
                {

                    contestPartRep.Add(new ContestPart
                    {
                        Contest = contest,
                        Partner = command.AuthorId
                    });

                }

                //TODO: Поразмыслить над тем как назначать время для конкурсов с комментариями
                contest.EndTime = DateTime.Now.AddMinutes(10);

                contestRep.Update(contest);
            }

            commentRep.Dispose();
        }
    }
}
