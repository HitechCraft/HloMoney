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

            mapping.Id(x => x.Id)
                .GeneratedBy.Increment();

            mapping.Map(x => x.VkId)
                .Length(128)
                .Column("VkId")
                .Not.Nullable();
            
            mapping.Map(x => x.Name)
                .Length(128)
                .Column("Name")
                .Not.Nullable();

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
