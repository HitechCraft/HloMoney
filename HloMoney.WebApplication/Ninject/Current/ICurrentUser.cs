namespace HloMoney.WebApplication.Ninject.Current
{
    using Models;

    public interface ICurrentUser
    {
        UserInfo Info { get; }
        UserInfo GetUserInfo();

        string Id { get; }
        string FullName { get; }
        string Avatar { get; }
    }
}
