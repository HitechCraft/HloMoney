namespace HloMoney.Core.Repository.Specification.Composite
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity.Base;

    #endregion

    public class NotSpecification<TEntity> : BaseSpecification<TEntity> where TEntity : BaseEntity<TEntity>
    {
        private readonly BaseSpecification<TEntity> _wrapped;

        public NotSpecification(BaseSpecification<TEntity> wrapped)
        {
            this._wrapped = wrapped;
        }

        public override Expression<Func<TEntity, bool>> IsSatisfiedBy()
        {
            var param = Expression.Parameter(typeof(TEntity), "x");
            var body = Expression.Not(Expression.Invoke(this._wrapped.IsSatisfiedBy(), param));

            return Expression.Lambda<Func<TEntity, bool>>(body, param);
        }
    }
}
