namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using Core.Models.Enum;
    using System;

    #endregion

    public class CommentCreateCommandHandler : BaseCommandHandler<CommentCreateCommand>
    {
        public CommentCreateCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(CommentCreateCommand command)
        {
            var commentRep = GetRepository<Comment>();
            
            commentRep.Add(new Comment
            {
                Text = command.Text,
                Author = command.AuthorId,
                Contest = this.GetRepository<Contest>().GetEntity(command.ContestId),
                Date = DateTime.Now
            });
            
            commentRep.Dispose();
        }
    }
}
