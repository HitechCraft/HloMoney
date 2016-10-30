namespace HloMoney.WebApplication.Controllers
{
    using System.Web.Mvc;
    using Core.DI;
    using System;

    public class UserController : BaseController
    {
        public UserController(IContainer container) : base(container)
        {
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public string UserAvatar()
        {
            return Convert.ToBase64String(this.CurrentUser.Info.Avatar);
        }
    }
}