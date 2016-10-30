namespace HloMoney.WebApplication.Mapper
{
    using Models;
    using Core.Entity;
    using Core.Helper;

    public class ContestPartToContestPartViewModelMapper : BaseMapper<ContestPart, ContestPartViewModel>
    {
        public ContestPartToContestPartViewModelMapper()
        {
            this.ConfigurationStore.CreateMap<ContestPart, ContestPartViewModel>()
                .ForMember(dst => dst.PartnerName, ext => ext.MapFrom(src => $"{src.Partner.FirstName} {src.Partner.LastName}"))
                .ForMember(dst => dst.PartnerAvatar, ext => ext.MapFrom(src => src.Partner.Avatar));
        }
    }
}