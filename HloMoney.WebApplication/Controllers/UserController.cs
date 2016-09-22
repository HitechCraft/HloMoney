﻿namespace HloMoney.WebApplication.Controllers
{
    using System.Web.Mvc;
    using Core.DI;

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

        public string UserAvatarLink()
        {
            return this.CurrentUser.Info.AvatarLink;
        }
    }
}