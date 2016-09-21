namespace HloMoney.Core.DI
{
    #region Using Directives

    using global::System;

    #endregion

    public interface IContainer
    {
        T Resolve<T>();

        object Resolve(Type type);
    }
}
