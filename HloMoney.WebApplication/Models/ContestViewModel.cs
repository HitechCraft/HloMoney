namespace HloMoney.WebApplication.Models
{
    using Core.Models.Enum;

    public class ContestViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Gift { get; set; }

        public byte[] Image { get; set; }

        public ContestType Type { get; set; }
    }
}