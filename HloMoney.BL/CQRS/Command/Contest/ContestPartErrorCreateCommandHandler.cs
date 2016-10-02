namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using System;
    using Core.Repository.Specification;

    #endregion

    public class ContestPartErrorCreateCommandHandler : BaseCommandHandler<ContestPartErrorCreateCommand>
    {
        public ContestPartErrorCreateCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(ContestPartErrorCreateCommand command)
        {
            var contestRep = GetRepository<Contest>();
            var contestPartErrorRep = GetRepository<ContestPartError>();

            contestPartErrorRep.Add(new ContestPartError
            {
                Contest = contestRep.GetEntity(command.ContestId),
                Error = command.Error
            });

            contestPartErrorRep.Dispose();
            contestRep.Dispose();
        }
    }
}
