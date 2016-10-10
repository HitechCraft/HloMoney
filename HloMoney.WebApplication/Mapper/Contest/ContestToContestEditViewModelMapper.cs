﻿namespace HloMoney.WebApplication.Mapper
{
    using Models;
    using Core.Entity;

    public class ContestToContestEditViewModelMapper : BaseMapper<Contest, ContestEditViewModel>
    {
        public ContestToContestEditViewModelMapper()
        {
            this.ConfigurationStore.CreateMap<Contest, ContestEditViewModel>()
                .ForMember(dst => dst.Id, ext => ext.MapFrom(src => src.Id))
                .ForMember(dst => dst.Description, ext => ext.MapFrom(src => src.Description))
                .ForMember(dst => dst.Gift, ext => ext.MapFrom(src => src.Gift))
                .ForMember(dst => dst.Image, ext => ext.MapFrom(src => src.Image));
        }
    }
}