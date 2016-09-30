namespace HloMoney.BL.CQRS.Command
{
    public class ContestTakePartCommand
    {
        public int ContestId { get; set; }

        public string UserId { get; set; }
    }
}
