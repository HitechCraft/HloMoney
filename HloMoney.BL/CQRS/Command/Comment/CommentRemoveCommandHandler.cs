namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using Core.Models.Enum;
    using System;

    #endregion

    public class CommentRemoveCommandHandler : BaseCommandHandler<CommentRemoveCommand>
    {
        public CommentRemoveCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(CommentRemoveCommand command)
        {
            var commentRep = GetRepository<Comment>();
            commentRep.Delete(command.Id);
            commentRep.Dispose();
        }
    }
}
