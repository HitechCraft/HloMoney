namespace HloMoney.BL.CQRS.Query.Entity
{
    #region Using Directives

    using Core.Entity.Base;
    using Base;
    using Core.Repository.Specification;

    #endregion

    public class EntityCountQuery<TEntity> : IQuery<int> where TEntity : BaseEntity<TEntity>
    {
        public ISpecification<TEntity> Specification { get; set; }
    }
}
