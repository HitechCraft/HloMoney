namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using System;
    using Core.Repository.Specification;

    #endregion

    public class ReportCreateCommandHandler : BaseCommandHandler<ReportCreateCommand>
    {
        public ReportCreateCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(ReportCreateCommand command)
        {
            var reportRep = GetRepository<Report>();
            var userInfoRep = this.GetRepository<UserInfo>();

            reportRep.Add(new Report
            {
                Title = command.Title,
                Text = command.Text,
                Author = userInfoRep.GetEntity(command.AuthorId),
                Mark = command.Mark,
                Date = DateTime.Now
            });

            reportRep.Dispose();
        }
    }
}
