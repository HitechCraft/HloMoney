﻿namespace HloMoney.DAL.NHibernate.Mappings
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Core.Entity;
    using System;

    #endregion

    public class TimeIncrementOverrides : IAutoMappingOverride<TimeIncrement>
    {
        public void Override(AutoMapping<TimeIncrement> mapping)
        {
            mapping.Table("TimeIncrement");

            mapping.Id(x => x.Id)
                .GeneratedBy.Increment();

            mapping.References(x => x.Contest)
                .Column("Contest")
                .Not.Nullable();
            
            mapping.Map(x => x.Increment)
                .Column("Increment")
                .Not.Nullable();
        }
    }
}