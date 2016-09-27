namespace HloMoney.BL.CQRS.Query.Entity
{
    #region Using Directives

    using Core.Entity.Base;
    using Core.Projector;
    using Base;

    #endregion

    public class EntityQuery<TEntity, TResult> : IQuery<TResult> where TEntity : BaseEntity<TEntity>
    {
        public object Id { get; set; }

        public IProjector<TEntity, TResult> Projector { get; set; }
    }
}
