namespace HloMoney.BL.CQRS.Query.Base
{
    public interface IQueryHandler<in TQuery, out TResult>
    {
        TResult Handle(TQuery query);
    }
}
