using System;

namespace HloMoney.BL.CQRS.Command
{
    public class ContestUpdateCommand
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Gift { get; set; }

        public byte[] Image { get; set; }

        public int WinnerCount { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
