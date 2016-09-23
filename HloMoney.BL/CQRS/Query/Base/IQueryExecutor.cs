namespace HloMoney.BL.CQRS.Query.Base
{
    public interface IQueryExecutor
    {
        TResult Execute<TResult, TQuery>(TQuery query);
    }
}
