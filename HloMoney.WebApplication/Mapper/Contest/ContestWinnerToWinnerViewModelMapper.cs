namespace HloMoney.WebApplication.Mapper
{
    using Models;
    using Core.Entity;
    using System.Linq;
    using Core.Helper;

    public class ContestWinnerToWinnerViewModelMapper : BaseMapper<ContestWinner, WinnerViewModel>
    {
        public ContestWinnerToWinnerViewModelMapper()
        {
            this.ConfigurationStore.CreateMap<ContestWinner, WinnerViewModel>()
                .ForMember(dst => dst.Name, ext => ext.MapFrom(src => src.Part.Partner.Name))
                .ForMember(dst => dst.Avatar, ext => ext.MapFrom(src => src.Part.Partner.Avatar))
                .ForMember(dst => dst.Place, ext => ext.MapFrom(src => src.Place));
        }
    }
}