namespace HloMoney.Core.Repository.Specification
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity;

    #endregion

    public class CommentByContestSpec : BaseSpecification<Comment>
    {
        #region Private Fields

        private readonly int _contestId;

        #endregion

        #region Constructor

        public CommentByContestSpec(int contestId)
        {
            _contestId = contestId;
        }

        #endregion

        #region Expression

        public override Expression<Func<Comment, bool>> IsSatisfiedBy()
        {
            return comment => comment.Contest.Id == this._contestId;
        }

        #endregion
    }
}
