namespace HloMoney.WebApplication.Mapper
{
    using Models;
    using Core.Entity;
    using System.Linq;
    using Core.Helper;

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
                .ForMember(dst => dst.Status, ext => ext.MapFrom(src => src.Status))
                .ForMember(dst => dst.EndTime, ext => ext.MapFrom(src => src.EndTime))
                .ForMember(dst => dst.Winners, ext => ext.MapFrom(src => src.Parts.Where(p => p.Winner != null).Select(x => x.Winner)))
                .ForMember(dst => dst.Comments, ext => ext.MapFrom(src => src.Comments));

            this.ConfigurationStore.CreateMap<ContestWinner, WinnerViewModel>()
                .ForMember(dst => dst.Name, ext => ext.MapFrom(src => src.Part.Partner.Name))
                .ForMember(dst => dst.Avatar, ext => ext.MapFrom(src => src.Part.Partner.Avatar))
                .ForMember(dst => dst.Place, ext => ext.MapFrom(src => src.Place));

            this.ConfigurationStore.CreateMap<Comment, CommentViewModel>()
                .ForMember(dst => dst.ContestId, ext => ext.MapFrom(src => src.Contest.Id))
                .ForMember(dst => dst.AuthorName, ext => ext.MapFrom(src => src.Author.Name))
                .ForMember(dst => dst.AuthorAvatar, ext => ext.MapFrom(src => src.Author.Avatar))
                .ForMember(dst => dst.Date, ext => ext.MapFrom(src => src.Date));
        }
    }
}