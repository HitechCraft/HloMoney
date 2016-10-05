namespace HloMoney.BL.CQRS.Command
{
    public class ContestUpdateCommand
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Gift { get; set; }

        public byte[] Image { get; set; }
    }
}
