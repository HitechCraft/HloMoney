namespace HloMoney.WebApplication.Controllers
{
    using System.Web.Mvc;
    using Core.DI;

    public class BaseController : Controller
    {
        public IContainer Container { get; set; }
        
        public BaseController(IContainer container)
        {
            this.Container = container;
        }
    }
}