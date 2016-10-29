namespace HloMoney.DAL.NHibernate.Mappings
{
    #region Using Directives

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Core.Entity;
    using System;

    #endregion

    public class UserInfoOverrides : IAutoMappingOverride<UserInfo>
    {
        public void Override(AutoMapping<UserInfo> mapping)
        {
            mapping.Table("UserInfo");

            mapping.Map(x => x.Id)
                .Generated.Insert();

            mapping.Id(x => x.VkId)
                .Length(128)
                .Column("VkId")
                .Not.Nullable();
            
            mapping.Map(x => x.FirstName)
                .Length(128)
                .Column("FirstName")
                .Not.Nullable();

            mapping.Map(x => x.LastName)
                .Length(128)
                .Column("LastName")
                .Not.Nullable();

            mapping.Map(x => x.BirthDate)
                .Column("BirthDate")
                .Nullable();

            mapping.Map(x => x.Avatar)
                .Length(Int32.MaxValue)
                .Column("Avatar")
                .Not.Nullable();
            
            mapping.Map(x => x.IsSynchron)
                .Column("IsSynchron")
                .Not.Nullable();

            mapping.Map(x => x.LastUpdate)
                .Column("LastUpdate")
                .Not.Nullable();
        }
    }
}
