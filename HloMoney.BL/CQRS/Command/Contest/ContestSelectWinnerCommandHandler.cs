namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using System;
    using Core.Repository.Specification;
    using Core.Helper;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class ContestSelectWinnerCommandHandler : BaseCommandHandler<ContestSelectWinnerCommand>
    {
        public ContestSelectWinnerCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(ContestSelectWinnerCommand command)
        {
            var contestRep = GetRepository<Contest>();
            var contestPartRep = GetRepository<ContestPart>();

            var contestWinnerRep = GetRepository<ContestWinner>();

            if (contestPartRep.Any())
                    throw new Exception("Участников нет");

            var contest = contestRep.GetEntity(command.ContestId);
            var contestParts = contestPartRep.Query(new ContestPartByContestSpec(command.ContestId));

            if (contestPartRep.Count() < contest.Winners)
                throw new Exception("Участников не достаточно");

            var randomParts = RandomHelper.GetRandomEntities(contestParts.ToList(), contest.Winners);

            foreach (var winner in randomParts)
            {
                contestWinnerRep.Add(new ContestWinner
                {
                    Part = winner
                });
            }

            contestWinnerRep.Dispose();
            contestPartRep.Dispose();
            contestRep.Dispose();
        }
    }
}
