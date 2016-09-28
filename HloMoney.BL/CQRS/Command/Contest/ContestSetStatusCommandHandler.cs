namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;

    #endregion

    public class ContestSetStatusCommandHandler : BaseCommandHandler<ContestSetStatusCommand>
    {
        public ContestSetStatusCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(ContestSetStatusCommand command)
        {
            var contestRep = GetRepository<Contest>();

            var contest = contestRep.GetEntity(command.Id);
            contest.Status = command.Status;

            contestRep.Update(contest);

            contestRep.Dispose();
        }
    }
}
