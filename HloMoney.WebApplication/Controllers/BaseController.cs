namespace HloMoney.WebApplication.Controllers
{
    using System.Web.Mvc;
    using Core.DI;
    using Core.Projector;
    using System.Linq;
    using Core.Helper;
    using Core.Models.Json;
    using Models;
    using Microsoft.AspNet.Identity;

    public class BaseController : Controller
    {
        #region Private Fields

        private UserInfo _userInfo;

        private ApplicationDbContext _context;

        #endregion

        #region Properties

        public IContainer Container { get; set; }

        public UserInfo UserInfo => _userInfo ?? (_userInfo = GetUserInfo());

        public ApplicationDbContext Context => _context ?? (_context = new ApplicationDbContext());

        #endregion

        public BaseController(IContainer container)
        {
            Container = container;
        }

        private UserInfo GetUserInfo()
        {
            var user = this.Context.Users.Find(User != null ? User.Identity.GetUserId() : "0");

            if (user != null)
            {
                var userVkLogin = user.Logins.FirstOrDefault(x => x.LoginProvider == "Vkontakte");

                return Project<JsonVkResponse, UserInfo>(VkApiHelper.GetUserInfo(userVkLogin != null ? userVkLogin.ProviderKey : "0").response.First());
            }

            return null;
        }

        public TResult Project<TSource, TResult>(TSource source)
        {
            return Container.Resolve<IProjector<TSource, TResult>>().Project(source);
        }
    }
}