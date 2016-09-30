namespace HloMoney.Core.Projector
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity.Base;

    #endregion

    public class CommonProjector<TSource, TResult> : BaseProjector<TSource, TResult> where TSource : BaseEntity<TSource>
    {
        #region Private Fields

        private readonly Expression<Func<TSource, TResult>> _expression;

        #endregion

        #region Constructor

        public CommonProjector(Expression<Func<TSource, TResult>> expression)
        {
            this._expression = expression;
        }

        #endregion

        public override Expression<Func<TSource, TResult>> ProjectExpr()
        {
            return this._expression;
        }
    }
}
