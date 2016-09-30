using HloMoney.Core.Entity.Base;

namespace HloMoney.Core.Entity
{
    public class ContestWinner : BaseEntity<ContestWinner>
    {
        /// <summary>
        /// Part, that is won contest
        /// </summary>
        public ContestPart Part { get; set; }
    }
}
