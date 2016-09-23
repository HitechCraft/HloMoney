namespace HloMoney.DAL.NHibernate.Mappings
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Core.Entity;

    #endregion

    public class ContestOverrides : IAutoMappingOverride<Contest>
    {
        public void Override(AutoMapping<Contest> mapping)
        {
            mapping.Table("Contest");

            mapping.Id(x => x.Id)
                .GeneratedBy.Increment();
        }
    }
}
