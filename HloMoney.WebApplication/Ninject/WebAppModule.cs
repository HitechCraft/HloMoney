namespace HloMoney.Ninjector.Dependences
{
    using Ninject.Modules;
    using Core.Projector;
    using WebApplication.Mapper;
    using Core.Models.Json;
    using WebApplication.Models;

    public class WebAppModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IProjector<,>)).To(typeof(BaseMapper<,>));

            Bind(typeof(IProjector<JsonVkResponse, UserInfoViewModel>)).To(typeof(JsonVkResponseToUserInfoViewModel));
        }
    }
}
