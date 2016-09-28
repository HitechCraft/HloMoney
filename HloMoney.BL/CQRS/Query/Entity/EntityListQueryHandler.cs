namespace HloMoney.BL.CQRS.Query.Entity
{
    #region Using Directives

    using System;
    using Core.DI;
    using Base;
    using Core.Entity.Base;
    using DAL.Repository;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class EntityListQueryHandler<TEntity, TResult>
        : BaseQueryHandler<EntityListQuery<TEntity, TResult>, ICollection<TResult>> where TEntity : BaseEntity<TEntity>
    {
        private readonly IContainer _container;

        public EntityListQueryHandler(IContainer container) : base(container)
        {
            _container = container;
        }

        public override ICollection<TResult> Handle(EntityListQuery<TEntity, TResult> query)
        {
            var entityRep = _container.Resolve<IRepository<TEntity>>();
            
            if (query.Projector == null)
                throw new Exception("Для получения объекта необходима проекция сущностей");

            return entityRep.Query(query.Specification, query.Projector).ToList();
        }
    }
}
