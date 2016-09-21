namespace HloMoney.Ninjector.Dependences
{
    using Core.DI;
    using Ninject.Modules;

    public class CommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IContainer)).To(typeof(BaseContainer));
        }
    }
}
