namespace HloMoney.BL.CQRS.Query.Base
{
    #region Using Directives

    using Command.Base;
    using Core.DI;
    using Core.Entity.Base;
    using Core.Projector;
    using DAL.Repository;

    #endregion

    public abstract class BaseQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
    {
        private readonly IContainer _container;

        protected BaseQueryHandler(IContainer container)
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

        public abstract TResult Handle(TQuery command);
    }
}
