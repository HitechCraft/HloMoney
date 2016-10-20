namespace HloMoney.BL.CQRS.Command
{
    public class ContestSelectWinnersCommand
    {
        public int ContestId { get; set; }
        
        public int WinnerCount { get; set; }
    }
}
