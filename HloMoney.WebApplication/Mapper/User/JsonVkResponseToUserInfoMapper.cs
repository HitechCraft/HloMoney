namespace HloMoney.WebApplication.Mapper
{
    using Core.Models.Json;
    using Models;
    using System;

    public class JsonVkResponseToUserInfoMapper : BaseMapper<JsonVkResponse, UserInfo>
    {
        public JsonVkResponseToUserInfoMapper()
        {
            this.ConfigurationStore.CreateMap<JsonVkResponse, UserInfo>()
                .ForMember(dst => dst.Id, ext => ext.MapFrom(src => src.id))
                .ForMember(dst => dst.FirstName, ext => ext.MapFrom(src => src.first_name))
                .ForMember(dst => dst.LastName, ext => ext.MapFrom(src => src.last_name))
                .ForMember(dst => dst.BirthDate, ext => ext.MapFrom(src => (!String.IsNullOrEmpty(src.bdate) ? (DateTime?)DateTime.Parse(src.bdate) : null)))
                .ForMember(dst => dst.AvatarLink, ext => ext.MapFrom(src => src.photo_200_orig))
                .ForMember(dst => dst.Status, ext => ext.MapFrom(src => src.online));
        }
    }
}