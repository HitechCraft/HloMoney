namespace HloMoney.DAL.NHibernate.Mappings
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using HloMoney.Core.Entity;

    #endregion

    public class ContestPartOverrides : IAutoMappingOverride<ContestPart>
    {
        public void Override(AutoMapping<ContestPart> mapping)
        {
            mapping.Table("ContestPart");

            mapping.Id(x => x.Id)
                .GeneratedBy.Increment();

            mapping.References(x => x.Contest)
                .Column("Contest")
                .Not.Nullable();

            mapping.References(x => x.Partner)
                .Column("Partner")
                .Not.Nullable();

            mapping.HasOne(x => x.Winner)
                .PropertyRef(x => x.Part);
        }
    }
}
