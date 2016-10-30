namespace HloMoney.BL.CQRS.Query
{
    #region Using Directives

    using Core.Entity.Base;
    using Base;
    using Core.Repository.Specification;
    using System.Collections.Generic;
    using HloMoney.Core.Projector;

    #endregion

    public class CommentNewQuery<TEntity, TResult> : IQuery<ICollection<TResult>> where TEntity : BaseEntity<TEntity>
    {
        public int LastCommentId { get; set; }

        public ISpecification<TEntity> Specification { get; set; }

        public IProjector<TEntity, TResult> Projector { get; set; }
    }
}
