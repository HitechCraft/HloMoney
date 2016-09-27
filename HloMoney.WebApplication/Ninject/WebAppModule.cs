using HloMoney.Core.Entity;

namespace HloMoney.Ninjector.Dependences
{
    using Ninject.Modules;
    using Core.Projector;
    using WebApplication.Mapper;
    using Core.Models.Json;
    using WebApplication.Models;
    using WebApplication.Ninject.Current;

    public class WebAppModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IProjector<,>)).To(typeof(BaseMapper<,>));
            Bind(typeof(ICurrentUser)).To(typeof(CurrentUser));

            Bind(typeof(IProjector<JsonVkResponse, UserInfo>)).To(typeof(JsonVkResponseToUserInfoMapper));
            Bind(typeof(IProjector<Contest, ContestViewModel>)).To(typeof(ContestToContestViewModelMapper));
        }
    }
}
