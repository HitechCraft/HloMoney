namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using System;
    using Core.Repository.Specification;

    #endregion

    public class ContestTakePartCommandHandler : BaseCommandHandler<ContestTakePartCommand>
    {
        public ContestTakePartCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(ContestTakePartCommand command)
        {
            var contestRep = GetRepository<Contest>();
            var contestPartRep = GetRepository<ContestPart>();

            if (contestPartRep.Exist(new ContestPartByContestSpec(command.ContestId) 
                & new ContestPartByUserSpec(command.UserId)))
                    throw new Exception("Вы уже приняли участие!");

            contestPartRep.Add(new ContestPart
            {
                Contest = contestRep.GetEntity(command.ContestId),
                UserId = command.UserId
            });

            contestPartRep.Dispose();
            contestRep.Dispose();
        }
    }
}
