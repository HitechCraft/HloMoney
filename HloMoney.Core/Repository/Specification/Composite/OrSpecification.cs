namespace HloMoney.Core.Repository.Specification.Composite
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity.Base;

    #endregion

    /// <summary>
    /// Specification for logic combining of other specifications
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class OrSpecification<TEntity> : BaseSpecification<TEntity> where TEntity : BaseEntity<TEntity>
    {
        private readonly BaseSpecification<TEntity> _left;
        private readonly BaseSpecification<TEntity> _right;

        public OrSpecification(BaseSpecification<TEntity> left, BaseSpecification<TEntity> right)
        {
            this._left = left;
            this._right = right;
        }

        public override Expression<Func<TEntity, bool>> IsSatisfiedBy()
        {
            var param = Expression.Parameter(typeof(TEntity), "x");

            var body = Expression.OrElse(
                    Expression.Invoke(this._left.IsSatisfiedBy(), param),
                    Expression.Invoke(this._right.IsSatisfiedBy(), param)
                );

            var lambda = Expression.Lambda<Func<TEntity, bool>>(body, param);

            return lambda;
        }
    }
}
