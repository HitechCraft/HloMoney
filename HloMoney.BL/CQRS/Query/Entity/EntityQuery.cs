namespace HloMoney.BL.CQRS.Query.Entity
{
    #region Using Directives

    using Core.Entity.Base;
    using Core.Projector;

    #endregion

    public class EntityQuery<TEntity, TResult> where TEntity : BaseEntity<TEntity>
    {
        public object Id { get; set; }

        public IProjector<TEntity, TResult> Projector { get; set; }
    }
}
