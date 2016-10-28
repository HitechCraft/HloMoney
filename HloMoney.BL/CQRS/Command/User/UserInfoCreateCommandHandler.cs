namespace HloMoney.BL.CQRS.Command
{
    #region Using Directives

    using Base;
    using Core.DI;
    using Core.Entity;
    using System;
    using Core.Repository.Specification;

    #endregion

    public class UserInfoCreateCommandHandler : BaseCommandHandler<UserInfoCreateCommand>
    {
        public UserInfoCreateCommandHandler(IContainer container) : base(container)
        {
        }

        public override void Handle(UserInfoCreateCommand command)
        {
            var userInfoRep = GetRepository<UserInfo>();

            userInfoRep.Add(new UserInfo
            {
                VkId = command.VkId,
                Avatar = command.Avatar,
                IsSynchron = true,
                Name = command.Name,
                LastUpdate = DateTime.Now
            });

            userInfoRep.Dispose();
        }
    }
}
