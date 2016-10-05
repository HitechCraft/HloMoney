namespace HloMoney.BL.CQRS.Command
{
    public class ContestCreateCommand
    {
        public string Description { get; set; }

        public string Gift { get; set; }

        public byte[] Image { get; set; }
    }
}
