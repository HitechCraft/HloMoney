using HloMoney.Core.Projector.Extentions;

namespace HloMoney.BL.CQRS.Query
{
    #region Using Directives
    
    using Core.DI;
    using Base;
    using Core.Entity.Base;
    using DAL.Repository;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class CommentNewQueryHandler<TEntity, TResult>
        : BaseQueryHandler<CommentNewQuery<TEntity, TResult>, ICollection<TResult>> where TEntity : BaseEntity<TEntity>
    {
        private readonly IContainer _container;

        public CommentNewQueryHandler(IContainer container) : base(container)
        {
            _container = container;
        }

        public override ICollection<TResult> Handle(CommentNewQuery<TEntity, TResult> query)
        {
            var entityRep = _container.Resolve<IRepository<TEntity>>();

            var allComments = entityRep.Query(query.Specification);
            var lastCommentIndex = allComments.ToList().IndexOf(entityRep.GetEntity(query.LastCommentId));

            var newComments = allComments.Skip(lastCommentIndex + 1);

            return newComments.Project(query.Projector).ToList();
        }
    }
}
