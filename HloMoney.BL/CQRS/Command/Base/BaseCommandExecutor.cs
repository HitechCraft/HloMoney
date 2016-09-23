namespace HloMoney.BL.CQRS.Command.Base
{
    #region Using Directives

    using Core.DI;

    #endregion

    public class BaseCommandExecutor : ICommandExecutor
    {
        private readonly IContainer _container;

        public BaseCommandExecutor(IContainer container)
        {
            this._container = container;
        }

        public void Execute<TCommand>(TCommand command)
        {
            var handler = this._container.Resolve<ICommandHandler<TCommand>>();

            handler.Handle(command);
        }
    }
}
