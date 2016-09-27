namespace HloMoney.Ninjector.Dependences
{
    using Core.DI;
    using Ninject.Modules;
    using BL.CQRS.Command.Base;
    using BL.CQRS.Query.Base;
    using BL.CQRS.Query.Entity;

    public class CommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IContainer)).To(typeof(BaseContainer));
        
            Bind(typeof(ICommandExecutor)).To(typeof(BaseCommandExecutor));
            Bind(typeof(ICommandHandler<>)).To(typeof(BaseCommandHandler<>));

            Bind(typeof(IQueryExecutor)).To(typeof(BaseQueryExecutor));
        }
    }
}
