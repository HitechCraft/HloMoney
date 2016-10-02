namespace HloMoney.Core.Entity
{
    using Base;

    public class ContestPartError : BaseEntity<ContestPartError>
    {
        public Contest Contest { get; set; }

        public string Error { get; set; }
    }
}
