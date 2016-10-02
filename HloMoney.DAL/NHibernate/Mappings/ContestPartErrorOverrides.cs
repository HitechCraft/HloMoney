namespace HloMoney.DAL.NHibernate.Mappings
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Core.Entity;
    using Core.Models.Enum;

    #endregion

    public class ContestPartErrorOverrides : IAutoMappingOverride<ContestPartError>
    {
        public void Override(AutoMapping<ContestPartError> mapping)
        {
            mapping.Table("ContestPartError");

            mapping.Id(x => x.Id)
                .GeneratedBy.Identity();

            mapping.References(x => x.Contest)
                .Column("Contest")
                .Not.Nullable();

            mapping.Map(x => x.Error)
                .Length(128)
                .Column("Error")
                .Not.Nullable();
        }
    }
}
