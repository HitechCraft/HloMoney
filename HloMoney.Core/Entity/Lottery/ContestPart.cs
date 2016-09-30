namespace HloMoney.Core.Entity
{
    using Base;

    public class ContestPart : BaseEntity<ContestPart>
    {
        public Contest Contest { get; set; }

        public string UserId { get; set; }
    }
}
