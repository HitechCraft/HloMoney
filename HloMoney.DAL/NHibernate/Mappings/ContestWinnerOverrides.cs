namespace HloMoney.DAL.NHibernate.Mappings
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Core.Entity;
    using Core.Models.Enum;

    #endregion

    public class ContestWinnerOverrides : IAutoMappingOverride<ContestWinner>
    {
        public void Override(AutoMapping<ContestWinner> mapping)
        {
            mapping.Table("ContestWinner");

            mapping.Id(x => x.Id)
                .GeneratedBy.Increment();

            mapping.References(x => x.Part)
                .Column("Part")
                .Not.Nullable();
        }
    }
}
