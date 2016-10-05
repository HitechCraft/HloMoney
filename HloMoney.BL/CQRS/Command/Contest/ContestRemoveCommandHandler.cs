namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using System;
    using Core.Repository.Specification;

    #endregion

    public class ContestRemoveCommandHandler : BaseCommandHandler<ContestRemoveCommand>
    {
        public ContestRemoveCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(ContestRemoveCommand command)
        {
            var contestRep = GetRepository<Contest>();
            
            contestRep.Delete(command.Id);
            contestRep.Dispose();
        }
    }
}
