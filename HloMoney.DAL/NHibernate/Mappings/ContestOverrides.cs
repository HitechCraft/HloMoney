namespace HloMoney.DAL.NHibernate.Mappings
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Core.Entity;
    using Core.Models.Enum;
    using System;

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

            mapping.Map(x => x.Image)
                .Length(Int32.MaxValue)
                .Column("Image")
                .Nullable();

            mapping.Map(x => x.WinnerCount)
                .Column("WinnerCount")
                .Not.Nullable();

            mapping.Map(x => x.Type)
                .CustomType<ContestType>()
                .Column("Type")
                .Not.Nullable();

            mapping.Map(x => x.Status)
                .CustomType<ContestStatus>()
                .Column("Status")
                .Not.Nullable();

            mapping.Map(x => x.StartTime)
                .Column("StartTime")
                .Not.Nullable();

            mapping.Map(x => x.EndTime)
                .Column("EndTime")
                .Not.Nullable();

            mapping.HasMany(x => x.Parts)
                .Cascade.All();

            mapping.HasMany(x => x.Comments)
                .Cascade.All();
        }
    }
}
