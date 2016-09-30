namespace HloMoney.BL.CQRS.Query.Entity
{
    #region Using Directives
    
    using Core.DI;
    using Base;
    using Core.Entity.Base;
    using DAL.Repository;
    using System.Linq;

    #endregion

    public class EntityExistsQueryHandler<TEntity>
        : BaseQueryHandler<EntityExistsQuery<TEntity>, bool> where TEntity : BaseEntity<TEntity>
    {
        private readonly IContainer _container;

        public EntityExistsQueryHandler(IContainer container) : base(container)
        {
            _container = container;
        }

        public override bool Handle(EntityExistsQuery<TEntity> query)
        {
            var entityRep = _container.Resolve<IRepository<TEntity>>();
            
            return entityRep.Query(query.Specification).Any();
        }
    }
}
