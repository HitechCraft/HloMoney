using System.Linq;
using HloMoney.Core.Helper;
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

    public class ContestEndCommandHandler : BaseCommandHandler<ContestEndCommand>
    {
        public ContestEndCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(ContestEndCommand command)
        {
            var contestRep = GetRepository<Contest>();
            var contestPartRep = GetRepository<ContestPart>();
            var contestWinnerRep = GetRepository<ContestWinner>();

            //end contest
            var contest = contestRep.GetEntity(command.ContestId);
            
            contest.Status = ContestStatus.Ended;
            contestRep.Update(contest);
            
            contestRep.Dispose();
        }
    }
}
