namespace HloMoney.WebApplication.Ninject.Current
{
    using Models;

    public interface ICurrentUser
    {
        UserInfo Info { get; }
        UserInfo GetUserInfo();
    }
}
