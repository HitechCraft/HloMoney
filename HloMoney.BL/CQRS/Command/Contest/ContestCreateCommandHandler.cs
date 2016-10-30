using System;

namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using Core.Models.Enum;

    #endregion

    public class ContestCreateCommandHandler : BaseCommandHandler<ContestCreateCommand>
    {
        public ContestCreateCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(ContestCreateCommand command)
        {
            var contestRep = GetRepository<Contest>();
            var timeIncrRep = GetRepository<TimeIncrement>();

            var status = ContestStatus.Started;

            if (command.Type == ContestType.Standart)
            {
                command.EndTime = null;
            }

            var contest = new Contest
            {
                Description = command.Description,
                Gift = command.Gift,
                Image = command.Image,
                Type = command.Type,
                WinnerCount = command.WinnerCount,
                Status = status,
                StartTime = DateTime.Now,
                EndTime = command.EndTime
            };

            contestRep.Add(contest);

            if (command.Type == ContestType.CommentTime)
            {
                timeIncrRep.Add(new TimeIncrement
                {
                    Contest = contest,
                    Increment = command.Increment
                });

                timeIncrRep.Dispose();
            }

            contestRep.Dispose();
        }
    }
}
