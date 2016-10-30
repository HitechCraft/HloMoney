namespace HloMoney.BL.CQRS.Command
{
    public class ReportCreateCommand
    {
        public string AuthorId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public float Mark { get; set; }
    }
}
