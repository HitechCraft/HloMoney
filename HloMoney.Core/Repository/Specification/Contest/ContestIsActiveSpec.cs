namespace HloMoney.Core.Repository.Specification.User
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity;
    using Models.Enum;

    #endregion

    public class ContestIsActiveSpec : BaseSpecification<Contest>
    {
        #region Constructor

        public ContestIsActiveSpec()
        {
        }

        #endregion

        #region Expression

        public override Expression<Func<Contest, bool>> IsSatisfiedBy()
        {
            return contest => contest.Status == ContestStatus.Started;
        }

        #endregion
    }
}
