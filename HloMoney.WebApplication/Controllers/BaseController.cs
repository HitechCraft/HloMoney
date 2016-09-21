namespace HloMoney.WebApplication.Controllers
{
    using System.Web.Mvc;
    using Core.DI;
    using Core.Projector;

    public class BaseController : Controller
    {
        public IContainer Container { get; set; }
        
        public BaseController(IContainer container)
        {
            this.Container = container;
        }

        public TResult Project<TSource, TResult>(TSource source)
        {
            return this.Container.Resolve<IProjector<TSource, TResult>>().Project(source);
        }
    }
}