namespace HloMoney.Core.Repository.Specification
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity;

    #endregion

    public class ContestPartByUserSpec : BaseSpecification<ContestPart>
    {
        #region Private Fields

        private readonly string _userId;

        #endregion

        #region Constructor

        public ContestPartByUserSpec(string userId)
        {
            this._userId = userId;
        }

        #endregion

        #region Expression

        public override Expression<Func<ContestPart, bool>> IsSatisfiedBy()
        {
            return contestPart => contestPart.Partner == this._userId;
        }

        #endregion
    }
}
