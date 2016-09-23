namespace HloMoney.BL.CQRS.Query.Entity
{
    #region Using Directives

    using System;
    using Core.DI;
    using Base;
    using Core.Entity.Base;
    using DAL.Repository;

    #endregion

    public class EntityQueryHandler<TEntity, TResult>
        : BaseQueryHandler<EntityQuery<TEntity, TResult>, TResult> where TEntity : BaseEntity<TEntity>
    {
        private readonly IContainer _container;

        public EntityQueryHandler(IContainer container) : base(container)
        {
            _container = container;
        }

        public override TResult Handle(EntityQuery<TEntity, TResult> query)
        {
            var entityRep = _container.Resolve<IRepository<TEntity>>();

            if (query.Projector == null)
                throw new Exception("Для получения объекта необходима проекция сущностей");

            return query.Projector.Project(entityRep.GetEntity(query.Id));
        }
    }
}
