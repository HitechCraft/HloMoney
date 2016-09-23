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

        public TResult Execute<TResult, TQuery>(TQuery command)
        {
            var handler = this._container.Resolve<IQueryHandler<TQuery, TResult>>();

            return handler.Handle(command);
        }
    }
}