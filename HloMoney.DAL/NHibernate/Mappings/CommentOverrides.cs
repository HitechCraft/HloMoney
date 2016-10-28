namespace HloMoney.DAL.NHibernate.Mappings
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Core.Entity;
    using System;

    #endregion

    public class CommentOverrides : IAutoMappingOverride<Comment>
    {
        public void Override(AutoMapping<Comment> mapping)
        {
            mapping.Table("Comment");

            mapping.Id(x => x.Id)
                .GeneratedBy.Increment();

            mapping.Map(x => x.Text)
                .Length(255)
                .Column("Text")
                .Not.Nullable();

            mapping.References(x => x.Contest)
                .Column("Contest")
                .Not.Nullable();

            mapping.References(x => x.Author)
                .Column("Author")
                .Not.Nullable();

            mapping.Map(x => x.Date)
                .Column("Date")
                .Not.Nullable();
        }
    }
}
