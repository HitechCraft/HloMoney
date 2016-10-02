namespace HloMoney.BL.CQRS.Command
{
    public class ContestPartErrorCreateCommand
    {
        public int ContestId { get; set; }

        public string Error { get; set; }
    }
}
