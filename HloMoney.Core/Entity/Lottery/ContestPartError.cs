namespace HloMoney.Core.Entity
{
    using Base;

    public class ContestPartError : BaseEntity<ContestPartError>
    {
        public virtual Contest Contest { get; set; }

        public virtual string Error { get; set; }
    }
}
