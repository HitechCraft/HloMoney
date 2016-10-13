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

            var contest = contestRep.GetEntity(command.Id);

            if(contest.StartTime < DateTime.Now)
                throw new Exception("Конкурс уже начался");
            if (contest.EndTime < DateTime.Now)
                throw new Exception("Конкурс уже закончился");
            
            contest.Description = command.Description;
            contest.Gift = command.Gift;
            contest.Image = command.Image;
            contest.WinnerCount = command.WinnerCount;

            contest.StartTime = command.StartTime;
            contest.EndTime = command.EndTime;

            contestRep.Update(contest);
            contestRep.Dispose();
        }
    }
}
