namespace HloMoney.DAL.NHibernate.Mappings
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using HloMoney.Core.Entity;

    #endregion

    public class AccountOverrides : IAutoMappingOverride<Account>
    {
        public void Override(AutoMapping<Account> mapping)
        {
            mapping.Table("Account");

            mapping.Map(x => x.Id)
                .Generated.Insert();

            mapping.Map(x => x.Name)
                .Length(128)
                .Not.Nullable();

            mapping.Id(x => x.UserId)
                .Column("UserId")
                .Length(128)
                .Not.Nullable();
            
            mapping.Map(x => x.Email)
                .Length(128)
                .Column("Email")
                .Not.Nullable();

            mapping.HasMany(x => x.Parts)
                .Cascade.All();
        }
    }
}
