namespace HloMoney.BL.CQRS.Command
{
    using System;
    using Core.Models.Enum;

    public class ContestTakePartCommand
    {
        public int ContestId { get; set; }

        public string UserId { get; set; }
    }
}
