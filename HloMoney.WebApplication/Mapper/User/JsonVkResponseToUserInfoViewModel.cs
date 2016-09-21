namespace HloMoney.WebApplication.Mapper
{
    using Core.Models.Json;
    using Models;
    using System;

    public class JsonVkResponseToUserInfoViewModel : BaseMapper<JsonVkResponse, UserInfoViewModel>
    {
        public JsonVkResponseToUserInfoViewModel()
        {
            this.ConfigurationStore.CreateMap<JsonVkResponse, UserInfoViewModel>()
                .ForMember(dst => dst.Id, ext => ext.MapFrom(src => src.id))
                .ForMember(dst => dst.FirstName, ext => ext.MapFrom(src => src.first_name))
                .ForMember(dst => dst.LastName, ext => ext.MapFrom(src => src.last_name))
                .ForMember(dst => dst.BirthDate, ext => ext.MapFrom(src => DateTime.Parse(src.bdate)))
                .ForMember(dst => dst.AvatarLink, ext => ext.MapFrom(src => src.photo_200_orig))
                .ForMember(dst => dst.Status, ext => ext.MapFrom(src => src.online));
        }
    }
}