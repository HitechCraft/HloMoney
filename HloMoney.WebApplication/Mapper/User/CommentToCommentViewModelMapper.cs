namespace HloMoney.WebApplication.Mapper
{
    using Models;
    using Core.Entity;
    using Core.Helper;

    public class CommentToCommentViewModelMapper : BaseMapper<Comment, CommentViewModel>
    {
        public CommentToCommentViewModelMapper()
        {
            this.ConfigurationStore.CreateMap<Comment, CommentViewModel>()
                .ForMember(dst => dst.Id, ext => ext.MapFrom(src => src.Id))
                .ForMember(dst => dst.ContestId, ext => ext.MapFrom(src => src.Contest.Id))
                .ForMember(dst => dst.AuthorName, ext => ext.MapFrom(src => VkApiHelper.GetUserName(src.Author)))
                .ForMember(dst => dst.AuthorAvatar, ext => ext.MapFrom(src => VkApiHelper.GetUserAvatar(src.Author)))
                .ForMember(dst => dst.Date, ext => ext.MapFrom(src => src.Date));
        }
    }
}