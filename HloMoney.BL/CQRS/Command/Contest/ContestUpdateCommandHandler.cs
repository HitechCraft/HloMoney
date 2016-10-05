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

            contest.Description = command.Description;
            contest.Gift = command.Gift;
            contest.Image = command.Image;

            contestRep.Update(contest);
            contestRep.Dispose();
        }
    }
}
