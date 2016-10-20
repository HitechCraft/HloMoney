namespace HloMoney.BL.CQRS.Query.Entity
{
    #region Using Directives

    using Core.Entity.Base;
    using Base;
    using Core.Repository.Specification;
    using Core.Projector;

    #endregion

    public class EntityLastQuery<TEntity, TResult> : IQuery<TResult> where TEntity : BaseEntity<TEntity>
    {
        public IProjector<TEntity, TResult> Projector { get; set; }
    }
}
