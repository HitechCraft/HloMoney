namespace HloMoney.Core.Entity
{
    #region Using Directives

    using Base;

    #endregion

    /// <summary>
    /// Entity of winning parts
    /// </summary>
    public class ContestWinner : BaseEntity<ContestWinner>
    {
        /// <summary>
        /// Part, that is winned
        /// </summary>
        public virtual ContestPart Part { get; set; }

        /// <summary>
        /// Winner place
        /// </summary>
        public virtual int Place { get; set; }
    }
}
