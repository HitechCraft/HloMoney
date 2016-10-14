namespace HloMoney.Core.Repository.Specification.User
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity;

    #endregion

    public class ContestPartByContestSpec : BaseSpecification<ContestPart>
    {
        #region Private Fields

        private readonly int _contestId;

        #endregion

        #region Constructor

        public ContestPartByContestSpec(int contestId)
        {
            this._contestId = contestId;
        }

        #endregion

        #region Expression

        public override Expression<Func<ContestPart, bool>> IsSatisfiedBy()
        {
            return contestPart => contestPart.Contest.Id == this._contestId;
        }

        #endregion
    }
}
