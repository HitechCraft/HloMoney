namespace HloMoney.Core.Repository.Specification
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity;

    #endregion

    public class TimeIncrementByContestSpec : BaseSpecification<TimeIncrement>
    {
        #region Private Fields

        private readonly int _contestId;

        #endregion

        #region Constructor

        public TimeIncrementByContestSpec(int contestId)
        {
           this._contestId = contestId;
        }

        #endregion

        #region Expression

        public override Expression<Func<TimeIncrement, bool>> IsSatisfiedBy()
        {
            return timeIncr => timeIncr.Contest.Id == this._contestId;
        }

        #endregion
    }
}
