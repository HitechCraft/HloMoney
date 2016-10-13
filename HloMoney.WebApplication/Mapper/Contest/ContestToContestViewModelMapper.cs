namespace HloMoney.WebApplication.Mapper
{
    using Models;
    using Core.Entity;

    public class ContestToContestViewModelMapper : BaseMapper<Contest, ContestViewModel>
    {
        public ContestToContestViewModelMapper()
        {
            this.ConfigurationStore.CreateMap<Contest, ContestViewModel>()
                .ForMember(dst => dst.Id, ext => ext.MapFrom(src => src.Id))
                .ForMember(dst => dst.Description, ext => ext.MapFrom(src => src.Description))
                .ForMember(dst => dst.Gift, ext => ext.MapFrom(src => src.Gift))
                .ForMember(dst => dst.Image, ext => ext.MapFrom(src => src.Image))
                .ForMember(dst => dst.WinnerCount, ext => ext.MapFrom(src => src.WinnerCount))
                .ForMember(dst => dst.Type, ext => ext.MapFrom(src => src.Type))
                .ForMember(dst => dst.EndTime, ext => ext.MapFrom(src => src.EndTime));
        }
    }
}