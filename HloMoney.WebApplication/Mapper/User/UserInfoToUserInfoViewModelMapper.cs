namespace HloMoney.WebApplication.Mapper
{
    using Models;
    using Core.Entity;

    public class UserInfoToUserInfoViewModelMapper : BaseMapper<UserInfo, UserInfoViewModel>
    {
        public UserInfoToUserInfoViewModelMapper()
        {
            this.ConfigurationStore.CreateMap<UserInfo, UserInfoViewModel>()
                .ForMember(dst => dst.Id, ext => ext.MapFrom(src => src.VkId))
                .ForMember(dst => dst.FirstName, ext => ext.MapFrom(src => src.FirstName))
                .ForMember(dst => dst.LastName, ext => ext.MapFrom(src => src.LastName))
                .ForMember(dst => dst.BirthDate, ext => ext.MapFrom(src => src.BirthDate))
                .ForMember(dst => dst.Avatar, ext => ext.MapFrom(src => src.Avatar))
                .ForMember(dst => dst.IsSynchron, ext => ext.MapFrom(src => src.IsSynchron))
                .ForMember(dst => dst.LastUpdate, ext => ext.MapFrom(src => src.LastUpdate));
        }
    }
}