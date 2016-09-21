﻿namespace HloMoney.WebApplication.Ninject.Current
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
        private UserInfo _info;
        private readonly IContainer _container;
        private readonly ApplicationDbContext _context;

        public UserInfo Info => _info ?? (_info = this.GetUserInfo());

        public CurrentUser(IContainer container)
        {
            this._container = container;
            this._context = new ApplicationDbContext();
        }

        public UserInfo GetUserInfo()
        {
            var user = this._context.Users.Find(HttpContext.Current.User.Identity != null ? HttpContext.Current.User.Identity.GetUserId() : "0");
            
            if (user != null)
            {
                var userVkLogin = user.Logins.FirstOrDefault(x => x.LoginProvider == "Vkontakte");

                return this._container.Resolve<IProjector<JsonVkResponse, UserInfo>>()
                    .Project(VkApiHelper.GetUserInfo(userVkLogin != null ? userVkLogin.ProviderKey : "0").response.First());
            }

            return null;
        }
    }
}