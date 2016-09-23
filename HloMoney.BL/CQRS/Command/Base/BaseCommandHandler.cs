namespace HloMoney.BL.CQRS.Command.Base
{
    #region Using Directives

    using Core.DI;
    using Core.Entity.Base;
    using Core.Projector;
    using DAL.Repository;

    #endregion

    public abstract class BaseCommandHandler<TCommand> : ICommandHandler<TCommand>
    {
        private readonly IContainer _container;

        protected BaseCommandHandler(IContainer container)
        {
            _container = container;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity<TEntity>
        {
            return _container.Resolve<IRepository<TEntity>>();
        }

        public IProjector<TEntity, TResult> GetProjector<TEntity, TResult>()
        {
            return _container.Resolve<IProjector<TEntity, TResult>>();
        }

        public abstract void Handle(TCommand command);
    }
}
