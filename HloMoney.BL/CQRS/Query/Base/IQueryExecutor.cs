namespace HloMoney.BL.CQRS.Query.Base
{
    public interface IQueryExecutor
    {
        TResult Execute<TResult>(IQuery<TResult> query) where TResult : class;
    }
}
