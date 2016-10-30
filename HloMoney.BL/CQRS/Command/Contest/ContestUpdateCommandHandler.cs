using System.Linq;

namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using System;
    using Core.Repository.Specification;

    #endregion

    public class ContestUpdateCommandHandler : BaseCommandHandler<ContestUpdateCommand>
    {
        public ContestUpdateCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(ContestUpdateCommand command)
        {
            var contestRep = GetRepository<Contest>();
            var timeIncrRep = GetRepository<TimeIncrement>();

            var contest = contestRep.GetEntity(command.Id);
            
            if (contest.EndTime < DateTime.Now)
                throw new Exception("Конкурс уже закончился");
            
            contest.Description = command.Description;
            contest.Gift = command.Gift;
            contest.Image = command.Image;
            contest.WinnerCount = command.WinnerCount;

            contest.StartTime = DateTime.Now;
            contest.EndTime = command.EndTime;

            contestRep.Update(contest);

            if (timeIncrRep.Exist(new TimeIncrementByContestSpec(contest.Id)) && command.Increment > 0)
            {
                var timeIncr = timeIncrRep.Query(new TimeIncrementByContestSpec(contest.Id)).First();

                timeIncr.Increment = command.Increment;

                timeIncrRep.Update(timeIncr);

                timeIncrRep.Dispose();
            }

            contestRep.Dispose();
        }
    }
}
