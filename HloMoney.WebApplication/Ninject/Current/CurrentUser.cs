using HloMoney.BL.CQRS.Command;
using HloMoney.BL.CQRS.Command.Base;
using HloMoney.BL.CQRS.Query.Entity;
using HloMoney.Core.Entity;
using HloMoney.Core.Repository.Specification.User;

namespace HloMoney.WebApplication.Ninject.Current
{
    using System.Linq;
    using Core.DI;
    using Core.Helper;
    using Core.Models.Json;
    using Models;
    using System.Web;
    using Core.Projector;
    using Microsoft.AspNet.Identity;

    public class CurrentUser : ICurrentUser
    {
        private UserInfoViewModel _info;
        private readonly IContainer _container;
        private readonly ApplicationDbContext _context;

        public UserInfoViewModel Info => _info ?? (_info = this.GetUserInfo());

        public string Id => Info.Id;
        public string FullName => $"{Info.FirstName} {Info.LastName}";
        public string Avatar => Info.AvatarLink;

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
                //TODO: закончить
                var source =
                    VkApiHelper.GetUsersInfo(userVkLogin != null ? userVkLogin.ProviderKey : "0").response;

                return this._container.Resolve<IProjector<JsonVkResponse, UserInfoViewModel>>()
                    .Project(source.First());
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
                this._container.Resolve<ICommandExecutor>().Execute(new UserInfoCreateCommand
                {
                    Avatar = VkApiHelper.GetUserAvatar(vkId),
                    Name = VkApiHelper.GetUserName(vkId),
                    VkId = vkId
                });
            }
        }
    }
}