namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using Core.Models.Enum;
    using System;
    using System.Linq;
    using Core.Helper;
    using Core.Repository.Specification;

    #endregion

    public class ContestSelectWinnersCommandHandler : BaseCommandHandler<ContestSelectWinnersCommand>
    {
        public ContestSelectWinnersCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(ContestSelectWinnersCommand command)
        {
            var contestRep = GetRepository<Contest>();
            var contestPartRep = GetRepository<ContestPart>();
            var contestWinnerRep = GetRepository<ContestWinner>();
            
            var contest = contestRep.GetEntity(command.ContestId);

            if (contest.Type != ContestType.CommentTime && contest.Type != ContestType.Standart)
            {
                //select winners
                if (contest.WinnerCount > contestPartRep.Count() || contestPartRep.Count() < command.MinPartCount)
                    throw new Exception("Участников конкурса не достаточно!");

                var parts = contestPartRep.Query(new ContestPartByContestSpec(contest.Id));
                var winnerNumbers = RandomHelper.GetRandomInts(contest.WinnerCount, parts.Count);

                for (int i = 0; i < contest.WinnerCount; i++)
                {
                    contestWinnerRep.Add(new ContestWinner
                    {
                        Part = parts.ToArray()[winnerNumbers[i]],
                        Place = i + 1
                    });
                }
            }

            if (contest.Type != ContestType.CommentTime)
            {
                var part = contestPartRep.Query(new ContestPartByContestSpec(contest.Id)).Last();

                contestWinnerRep.Add(new ContestWinner
                {
                    Part = part,
                    Place = 1
                });
            }

            contestWinnerRep.Dispose();
            contestPartRep.Dispose();
            contestRep.Dispose();
        }
    }
}
