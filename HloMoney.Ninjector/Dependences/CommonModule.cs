namespace HloMoney.Ninjector.Dependences
{
    using Core.DI;
    using Ninject.Modules;
    using BL.CQRS.Command.Base;
    using BL.CQRS.Query.Base;
    using BL.CQRS.Command;
    using DAL.Repository;
    using DAL.UnitOfWork;

    public class CommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IContainer)).To(typeof(BaseContainer));
        
            Bind(typeof(ICommandExecutor)).To(typeof(BaseCommandExecutor));
            Bind(typeof(ICommandHandler<>)).To(typeof(BaseCommandHandler<>));
            Bind(typeof(ICommandHandler<ContestSetStatusCommand>)).To(typeof(ContestSetStatusCommandHandler));
            Bind(typeof(ICommandHandler<ContestTakePartCommand>)).To(typeof(ContestTakePartCommandHandler));

            Bind(typeof(IRepository<>)).To(typeof(BaseRepository<>));
            Bind(typeof(IUnitOfWork)).To(typeof(NHibernateUnitOfWork));

            Bind(typeof(IQueryExecutor)).To(typeof(BaseQueryExecutor));
        }
    }
}
