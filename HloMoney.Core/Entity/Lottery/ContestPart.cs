namespace HloMoney.Core.Entity
{
    using Base;

    public class ContestPart : BaseEntity<ContestPart>
    {
        public virtual Contest Contest { get; set; }

        public virtual string UserId { get; set; }
    }
}
