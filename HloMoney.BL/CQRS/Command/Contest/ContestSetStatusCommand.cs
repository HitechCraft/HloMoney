namespace HloMoney.BL.CQRS.Command
{
    using Core.Models.Enum;

    public class ContestSetStatusCommand
    {
        public int Id { get; set; }

        public ContestStatus Status { get; set; }
    }
}
