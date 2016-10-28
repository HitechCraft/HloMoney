namespace HloMoney.WebApplication.Ninject.Current
{
    using Models;

    public interface ICurrentUser
    {
        UserInfoViewModel Info { get; }
        UserInfoViewModel GetUserInfo();

        string Id { get; }
        string FullName { get; }
        string Avatar { get; }
    }
}
