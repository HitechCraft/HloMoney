namespace HloMoney.WebApplication.Models
{
    using Core.Models.Enum;
    using System;

    public class ContestViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Gift { get; set; }

        public byte[] Image { get; set; }

        public ContestType Type { get; set; }

        public ContestStatus Status { get; set; }

        public int Winners { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}