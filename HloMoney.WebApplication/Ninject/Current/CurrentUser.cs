namespace HloMoney.WebApplication.Ninject.Current
{
    #region Using Directives

    using System.Linq;
    using Core.DI;
    using Core.Helper;
    using Models;
    using System.Web;
    using Core.Projector;
    using Microsoft.AspNet.Identity;
    using System;
    using HloMoney.BL.CQRS.Command;
    using HloMoney.BL.CQRS.Command.Base;
    using HloMoney.BL.CQRS.Query.Entity;
    using HloMoney.Core.Entity;
    using HloMoney.Core.Repository.Specification.User;

    #endregion

    public class CurrentUser : ICurrentUser
    {
        private UserInfoViewModel _info;
        private readonly IContainer _container;
        private readonly ApplicationDbContext _context;

        public UserInfoViewModel Info => _info ?? (_info = this.GetUserInfo());

        public string Id => Info.Id;
        public string FullName => $"{Info.FirstName} {Info.LastName}";
        public byte[] Avatar => Info.Avatar;

        public CurrentUser(IContainer container)
        {
            this._container = container;
            this._context = new ApplicationDbContext();
        }

        public UserInfoViewModel GetUserInfo()
        {
            var user = this._context.Users.Find(HttpContext.Current.User.Identity != null ? HttpContext.Current.User.Identity.GetUserId() : "0");
            
            if (user != null)
            {
                var userVkLogin = user.Logins.FirstOrDefault(x => x.LoginProvider == "Vkontakte");
                this.CheckerInfo(userVkLogin != null ? userVkLogin.ProviderKey : "0");
                
                return this.GetUserInfo(userVkLogin != null ? userVkLogin.ProviderKey : "0");
            }

            return null;
        }
        
        private void CheckerInfo(string vkId)
        {
            if (!new EntityExistsQueryHandler<UserInfo>(this._container)
                            .Handle(new EntityExistsQuery<UserInfo>
                            {
                                Specification = new UserInfoByVkIdSpec(vkId)
                            }))
            {
                var info = VkApiHelper.GetUsersInfo(vkId).response.First();

                this._container.Resolve<ICommandExecutor>().Execute(new UserInfoCreateCommand
                {
                    Avatar = VkApiHelper.GetUserAvatar(vkId, info.photo_max),
                    FirstName = info.first_name,
                    LastName = info.last_name,
                    BirthDate = (String.IsNullOrEmpty(info.bdate) ? null : (DateTime?)DateTime.Parse(info.bdate)),
                    VkId = vkId
                });
            }
        }

        private UserInfoViewModel GetUserInfo(string vkId)
        {
            return new EntityQueryHandler<UserInfo, UserInfoViewModel>(this._container)
                .Handle(new EntityQuery<UserInfo, UserInfoViewModel>
                {
                    Id = vkId,
                    Projector = this._container.Resolve<IProjector<UserInfo, UserInfoViewModel>>()
                });
        }
    }
}