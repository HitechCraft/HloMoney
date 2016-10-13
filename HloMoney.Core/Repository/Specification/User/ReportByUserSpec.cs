namespace HloMoney.Core.Repository.Specification.User
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity;

    #endregion

    public class ReportByUserSpec : BaseSpecification<Report>
    {
        #region Private Fields

        private readonly string _userId;

        #endregion

        #region Constructor

        public ReportByUserSpec(string userId)
        {
            this._userId = userId;
        }

        #endregion

        #region Expression

        public override Expression<Func<Report, bool>> IsSatisfiedBy()
        {
            return report => report.Author == this._userId;
        }

        #endregion
    }
}
