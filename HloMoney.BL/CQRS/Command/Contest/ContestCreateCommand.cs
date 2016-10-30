namespace HloMoney.BL.CQRS.Command
{
    using System;
    using Core.Models.Enum;

    public class ContestCreateCommand
    {
        public string Description { get; set; }

        public string Gift { get; set; }

        public byte[] Image { get; set; }

        public ContestType Type { get; set; }

        public float Increment { get; set; }

        public int WinnerCount { get; set; }
        
        public DateTime? EndTime { get; set; }
    }
}
