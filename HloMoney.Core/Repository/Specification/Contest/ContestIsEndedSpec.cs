namespace HloMoney.Core.Repository.Specification
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity;

    #endregion

    public class ContestIsEndedSpec : BaseSpecification<Contest>
    {
        #region Constructor

        public ContestIsEndedSpec()
        {
        }

        #endregion

        #region Expression

        public override Expression<Func<Contest, bool>> IsSatisfiedBy()
        {
            return contest => contest.EndTime < DateTime.Now;
        }

        #endregion
    }
}
