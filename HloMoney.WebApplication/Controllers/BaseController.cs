﻿namespace HloMoney.WebApplication.Controllers
{
    using System.Web.Mvc;
    using Core.DI;
    using Core.Projector;
    using Ninject.Current;

    public class BaseController : Controller
    {
        #region Private Fields

        private ICurrentUser _currentUser;

        #endregion

        #region Properties

        public IContainer Container { get; set; }

        public ICurrentUser CurrentUser { get; set; }

        #endregion

        public BaseController(IContainer container)
        {
            this.Container = container;
            this.CurrentUser = this.Container.Resolve<ICurrentUser>();
        }
        
        public TResult Project<TSource, TResult>(TSource source)
        {
            return Container.Resolve<IProjector<TSource, TResult>>().Project(source);
        }
    }
}