namespace HitechCraft.Core.Repository.Specification
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using HloMoney.Core.Entity;
    using HloMoney.Core.Repository.Specification;

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
