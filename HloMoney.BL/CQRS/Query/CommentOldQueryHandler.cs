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

    public class CommentOldQueryHandler<TEntity, TResult>
        : BaseQueryHandler<CommentOldQuery<TEntity, TResult>, ICollection<TResult>> where TEntity : BaseEntity<TEntity>
    {
        private readonly IContainer _container;

        public CommentOldQueryHandler(IContainer container) : base(container)
        {
            _container = container;
        }
            
        public override ICollection<TResult> Handle(CommentOldQuery<TEntity, TResult> query)
        {
            var entityRep = _container.Resolve<IRepository<TEntity>>();

            var allComments = entityRep.Query(query.Specification);
            var lastCommentIndex = allComments.ToList().IndexOf(entityRep.GetEntity(query.LastCommentId));

            var newComments = allComments.Reverse().Skip(allComments.Count - lastCommentIndex);

            return newComments.Project(query.Projector).ToList();
        }
    }
}
