namespace HloMoney.DAL.NHibernate
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using Helper;
    using Core.Entity;
    using Mappings;

    #endregion

    /// <summary>
    /// Mappings for NHibernate entities
    /// Nice mapping info https://github.com/jagregory/fluent-nhibernate/wiki/Fluent-mapping
    /// </summary>
    public static class MappingConfig
    {
        public static AutoMappingsContainer AutoMappings(this MappingConfiguration mapConfig,
            AutomappingHelper autoMapHelper)
        {
            return mapConfig.AutoMappings
                .Add(AutoMap.AssemblyOf<Contest>(autoMapHelper)
                    .UseOverridesFromAssemblyOf<ContestOverrides>())
                .Add(AutoMap.AssemblyOf<ContestPart>(autoMapHelper)
                    .UseOverridesFromAssemblyOf<ContestPartOverrides>())
                .Add(AutoMap.AssemblyOf<ContestWinner>(autoMapHelper)
                    .UseOverridesFromAssemblyOf<ContestWinnerOverrides>());
        }
    }
}
