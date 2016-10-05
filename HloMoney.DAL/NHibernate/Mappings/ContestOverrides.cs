namespace HloMoney.DAL.NHibernate.Mappings
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Core.Entity;
    using Core.Models.Enum;

    #endregion

    public class ContestOverrides : IAutoMappingOverride<Contest>
    {
        public void Override(AutoMapping<Contest> mapping)
        {
            mapping.Table("Contest");

            mapping.Id(x => x.Id)
                .GeneratedBy.Identity();

            mapping.Map(x => x.Description)
                .Length(2000)
                .Column("Description")
                .Not.Nullable();
            
            mapping.Map(x => x.Gift)
                .Length(128)
                .Column("Gift")
                .Not.Nullable();
        }
    }
}
