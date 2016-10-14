namespace HloMoney.Core.Repository.Specification.User
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity;
    using Models.Enum;

    #endregion

    public class ContestIsGlobalSpec : BaseSpecification<Contest>
    {
        #region Constructor

        public ContestIsGlobalSpec()
        {
        }

        #endregion

        #region Expression

        public override Expression<Func<Contest, bool>> IsSatisfiedBy()
        {
            return contest => contest.Type == ContestType.Global;
        }

        #endregion
    }
}
