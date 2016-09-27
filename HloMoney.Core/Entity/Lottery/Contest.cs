namespace HloMoney.Core.Entity
{
    using Base;
    using Models.Enum;

    public class Contest : BaseEntity<Contest>
    {
        public virtual string Description { get; set; }

        public virtual string Gift { get; set; }

        public virtual byte[] Image { get; set; }

        public virtual ContestType Type { get; set; }
    }
}
