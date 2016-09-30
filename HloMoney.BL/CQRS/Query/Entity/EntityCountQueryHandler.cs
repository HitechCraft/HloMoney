namespace HloMoney.BL.CQRS.Query.Entity
{
    #region Using Directives

    using System;
    using Core.DI;
    using Base;
    using Core.Entity.Base;
    using DAL.Repository;

    #endregion

    public class EntityCountQueryHandler<TEntity>
        : BaseQueryHandler<EntityCountQuery<TEntity>, int> where TEntity : BaseEntity<TEntity>
    {
        private readonly IContainer _container;

        public EntityCountQueryHandler(IContainer container) : base(container)
        {
            _container = container;
        }

        public override int Handle(EntityCountQuery<TEntity> query)
        {
            var entityRep = _container.Resolve<IRepository<TEntity>>();
            
            return entityRep.Query(query.Specification).Count;
        }
    }
}
