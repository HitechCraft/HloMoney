namespace HloMoney.WebApplication.Models
{
    using System;
    using Core.Models.Enum;
    using System.Collections.Generic;

    public class ContestViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Gift { get; set; }

        public byte[] Image { get; set; }

        public int WinnerCount { get; set; }

        public ContestType Type { get; set; }
        
        public DateTime? EndTime { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}