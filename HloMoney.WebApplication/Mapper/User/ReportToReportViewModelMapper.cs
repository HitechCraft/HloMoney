﻿namespace HloMoney.WebApplication.Mapper
{
    using Models;
    using Core.Entity;

    public class ReportToReportViewModelMapper : BaseMapper<Report, ReportViewModel>
    {
        public ReportToReportViewModelMapper()
        {
            this.ConfigurationStore.CreateMap<Report, ReportViewModel>()
                .ForMember(dst => dst.Id, ext => ext.MapFrom(src => src.Id))
                .ForMember(dst => dst.Title, ext => ext.MapFrom(src => src.Title))
                .ForMember(dst => dst.Text, ext => ext.MapFrom(src => src.Text))
                .ForMember(dst => dst.AuthorName, ext => ext.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"))
                .ForMember(dst => dst.AuthorAvatar, ext => ext.MapFrom(src => src.Author.Avatar))
                .ForMember(dst => dst.Mark, ext => ext.MapFrom(src => src.Mark))
                .ForMember(dst => dst.Date, ext => ext.MapFrom(src => src.Date));
        }
    }
}