namespace HloMoney.BL.CQRS.Query.Entity
{
    #region Using Directives

    using Core.Entity.Base;
    using Core.Projector;
    using Base;
    using Core.Repository.Specification;
    using System.Collections.Generic;

    #endregion

    public class EntityListQuery<TEntity, TResult> : IQuery<ICollection<TResult>> where TEntity : BaseEntity<TEntity>
    {
        public ISpecification<TEntity> Specification { get; set; }

        public IProjector<TEntity, TResult> Projector { get; set; }
    }
}
