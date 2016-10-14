namespace HloMoney.Core.Repository.Specification
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity;

    #endregion

    public class ContestWinnerSpec : BaseSpecification<ContestWinner>
    {
        #region Private Fields

        private readonly int _contestId;

        #endregion

        #region Constructor

        public ContestWinnerSpec(int contestId)
        {
            _contestId = contestId;
        }

        #endregion

        #region Expression

        public override Expression<Func<ContestWinner, bool>> IsSatisfiedBy()
        {
            return contestWinner => contestWinner.Part.Contest.Id == this._contestId;
        }

        #endregion
    }
}
