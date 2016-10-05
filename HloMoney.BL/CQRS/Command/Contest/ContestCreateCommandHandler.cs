namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using System;
    using Core.Repository.Specification;

    #endregion

    public class ContestCreateCommandHandler : BaseCommandHandler<ContestCreateCommand>
    {
        public ContestCreateCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(ContestCreateCommand command)
        {
            var contestRep = GetRepository<Contest>();

            contestRep.Add(new Contest
            {
                Description = command.Description,
                Gift = command.Gift,
                Image = command.Image
            });
            
            contestRep.Dispose();
        }
    }
}
