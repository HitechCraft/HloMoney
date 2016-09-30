namespace HloMoney.DAL.NHibernate.Mappings
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Core.Entity;
    using Core.Models.Enum;

    #endregion

    public class ContestPartOverrides : IAutoMappingOverride<ContestPart>
    {
        public void Override(AutoMapping<ContestPart> mapping)
        {
            mapping.Table("ContestPart");

            mapping.Id(x => x.Id)
                .GeneratedBy.Identity();

            mapping.References(x => x.Contest)
                .Column("Contest")
                .Not.Nullable();
            
            mapping.Map(x => x.UserId)
                .Length(128)
                .Column("UserId")
                .Not.Nullable();
        }
    }
}
