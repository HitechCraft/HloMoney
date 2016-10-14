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

            var status = ContestStatus.New;

            if (command.Type == ContestType.Standart)
            {
                command.StartTime = null;
                command.EndTime = null;

                status = ContestStatus.Started;
            }

            contestRep.Add(new Contest
            {
                Description = command.Description,
                Gift = command.Gift,
                Image = command.Image,
                Type = command.Type,
                WinnerCount = command.WinnerCount,
                Status = status,
                StartTime = command.StartTime,
                EndTime = command.EndTime
            });
            
            contestRep.Dispose();
        }
    }
}
