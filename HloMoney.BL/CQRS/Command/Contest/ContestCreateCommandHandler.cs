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
            
            var status = ContestStatus.Started;

            if (command.Type == ContestType.Standart)
            {
                command.EndTime = null;
            }

            contestRep.Add(new Contest
            {
                Description = command.Description,
                Gift = command.Gift,
                Image = command.Image,
                Type = command.Type,
                WinnerCount = command.WinnerCount,
                Status = status,
                StartTime = DateTime.Now,
                EndTime = command.EndTime
            });
            
            contestRep.Dispose();
        }
    }
}
