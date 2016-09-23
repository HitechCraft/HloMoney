namespace HloMoney.Core.Repository.Specification
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity.Base;

    #endregion

    public interface ISpecification<TEntity> where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Returning specific expression
        /// </summary>
        /// <returns></returns>
        Expression<Func<TEntity, bool>> IsSatisfiedBy();
    }
}
