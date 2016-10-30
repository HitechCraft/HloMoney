using HloMoney.Core.Repository.Specification;

namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using Core.Models.Enum;
    using System;

    #endregion

    public class ContestTakePartCommandHandler : BaseCommandHandler<ContestTakePartCommand>
    {
        public ContestTakePartCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(ContestTakePartCommand command)
        {
            var contestPartRep = GetRepository<ContestPart>();
            var contesRep = GetRepository<Contest>();
            var userInfoRep = this.GetRepository<UserInfo>();

            if (
                contestPartRep.Exist(new ContestPartByContestSpec(command.ContestId) &
                                     new ContestPartByUserSpec(command.UserId)))
                throw new Exception("Вы уже приняли участие!");

            contestPartRep.Add(new ContestPart
            {
                Contest = contesRep.GetEntity(command.ContestId),
                Partner = userInfoRep.GetEntity(command.UserId)
            });

            contestPartRep.Dispose();
        }
    }
}
