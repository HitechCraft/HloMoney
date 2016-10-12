namespace HloMoney.DAL.NHibernate.Mappings
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using HloMoney.Core.Entity;

    #endregion

    public class ReportOverrides : IAutoMappingOverride<Report>
    {
        public void Override(AutoMapping<Report> mapping)
        {
            mapping.Table("Report");

            mapping.Id(x => x.Id)
                .GeneratedBy.Increment();

            mapping.Map(x => x.Title)
                .Length(128)
                .Column("Title")
                .Not.Nullable();

            mapping.Map(x => x.Text)
                .Length(2000)
                .Column("Text")
                .Not.Nullable();

            mapping.Map(x => x.Author)
                .Column("Author")
                .Not.Nullable();

            mapping.Map(x => x.Mark)
                .Column("Mark")
                .Not.Nullable();

            mapping.Map(x => x.Date)
                .Column("Date")
                .Not.Nullable();
        }
    }
}
