using System.Linq;
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
            var userInfoRep = this.GetRepository<UserInfo>();
            var timeIncrRep = GetRepository<TimeIncrement>();

            var contest = contestRep.GetEntity(command.ContestId);

            commentRep.Add(new Comment
            {
                Text = command.Text,
                Author = userInfoRep.GetEntity(command.AuthorId),
                Contest = contest,
                Date = DateTime.Now
            });

            if (contest.Type == ContestType.CommentTime && contest.Status == ContestStatus.Started)
            {
                if (
                    !contestPartRep.Exist(new ContestPartByContestSpec(contest.Id) &
                                          new ContestPartByUserSpec(command.AuthorId)))
                {

                    contestPartRep.Add(new ContestPart
                    {
                        Contest = contest,
                        Partner = userInfoRep.GetEntity(command.AuthorId)
                    });

                }

                var timeIncr = timeIncrRep.Query(new TimeIncrementByContestSpec(contest.Id)).First();
                
                contest.EndTime = DateTime.Now.AddMinutes(timeIncr.Increment);

                contestRep.Update(contest);
            }

            commentRep.Dispose();
        }
    }
}
