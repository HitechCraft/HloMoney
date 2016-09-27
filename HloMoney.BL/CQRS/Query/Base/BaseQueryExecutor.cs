namespace HloMoney.BL.CQRS.Query.Base
{
    #region Using Directives

    using Core.DI;

    #endregion

    public class BaseQueryExecutor : IQueryExecutor
    {
        private readonly IContainer _container;

        public BaseQueryExecutor(IContainer container)
        {
            this._container = container;
        }

        public TResult Execute<TResult>(IQuery<TResult> command) where TResult : class
        {
            var handler = this._container.Resolve<IQueryHandler<IQuery<TResult>, TResult>>();

            return handler.Handle(command);
        }
    }
}