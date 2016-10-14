namespace HloMoney.Core.Repository.Specification.User
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity;
    using Models.Enum;

    #endregion

    public class ContestIsNewSpec : BaseSpecification<Contest>
    {
        #region Constructor

        public ContestIsNewSpec()
        {
        }

        #endregion

        #region Expression

        public override Expression<Func<Contest, bool>> IsSatisfiedBy()
        {
            return contest => contest.Status == ContestStatus.New;
        }

        #endregion
    }
}
