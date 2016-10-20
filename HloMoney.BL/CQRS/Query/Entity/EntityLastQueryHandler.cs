using System.Collections.Generic;

namespace HloMoney.BL.CQRS.Query.Entity
{
    #region Using Directives
    
    using Core.DI;
    using Base;
    using Core.Entity.Base;
    using DAL.Repository;
    using System.Linq;

    #endregion

    public class EntityLastQueryHandler<TEntity, TResult>
        : BaseQueryHandler<EntityLastQuery<TEntity, TResult>, TResult> where TEntity : BaseEntity<TEntity>
    {
        private readonly IContainer _container;

        public EntityLastQueryHandler(IContainer container) : base(container)
        {
            _container = container;
        }

        public override TResult Handle(EntityLastQuery<TEntity, TResult> query)
        {
            var entityRep = _container.Resolve<IRepository<TEntity>>();
            
            return query.Projector.Project(((IEnumerable<TEntity>)entityRep.Query()).Last());
        }
    }
}
