namespace HloMoney.Core.Entity
{
    #region Using Directives

    using Base;

    #endregion

    /// <summary>
    /// Entity of taking contest part
    /// </summary>
    public class ContestPart : BaseEntity<ContestPart>
    {
        /// <summary>
        /// Contest
        /// </summary>
        public virtual Contest Contest { get; set; }

        /// <summary>
        /// User vk id, that took contest part
        /// </summary>
        public virtual Account Partner { get; set; }

        /// <summary>
        /// Winner reference
        /// </summary>
        public virtual ContestWinner Winner { get; set; }
    }
}
