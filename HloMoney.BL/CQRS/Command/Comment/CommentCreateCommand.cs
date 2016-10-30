namespace HloMoney.BL.CQRS.Command
{
    public class CommentCreateCommand
    {
        public string Text { get; set; }

        public string AuthorId { get; set; }

        public int ContestId { get; set; }
    }
}
