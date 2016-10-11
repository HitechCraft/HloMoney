namespace HloMoney.DAL.NHibernate.Mappings
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using HloMoney.Core.Entity;

    #endregion

    public class CommentOverrides : IAutoMappingOverride<Comment>
    {
        public void Override(AutoMapping<Comment> mapping)
        {
            mapping.Table("Comment");

            mapping.Id(x => x.Id)
                .GeneratedBy.Identity();

            mapping.Map(x => x.Text)
                .Length(255)
                .Column("Text")
                .Not.Nullable();

            mapping.References(x => x.Contest)
                .Column("Contest")
                .Not.Nullable();

            mapping.Map(x => x.AuthorId)
                .Column("AuthorId")
                .Not.Nullable();

            mapping.Map(x => x.Date)
                .Column("Date")
                .Not.Nullable();
        }
    }
}
