namespace HloMoney.WebApplication.Mapper
{
    using Models;
    using Core.Entity;

    public class ReportToReportCreateViewModelMapper : BaseMapper<Report, ReportCreateViewModel>
    {
        public ReportToReportCreateViewModelMapper()
        {
            this.ConfigurationStore.CreateMap<Report, ReportCreateViewModel>()
                .ForMember(dst => dst.Title, ext => ext.MapFrom(src => src.Title))
                .ForMember(dst => dst.Text, ext => ext.MapFrom(src => src.Text))
                .ForMember(dst => dst.Mark, ext => ext.MapFrom(src => src.Mark));
        }
    }
}