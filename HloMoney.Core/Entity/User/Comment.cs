namespace HloMoney.Core.Entity
{
    #region Using Directives

    using Base;
    using System;

    #endregion

    /// <summary>
    /// Entity for user comments
    /// </summary>
    public class Comment : BaseEntity<Comment>
    {
        /// <summary>
        /// Comment text
        /// </summary>
        public virtual string Text { get; set; }

        /// <summary>
        /// Author
        /// </summary>
        public virtual UserInfo Author { get; set; }

        /// <summary>
        /// Contest this comment belong
        /// </summary>
        public virtual Contest Contest { get; set; }

        /// <summary>
        /// Comment added date
        /// </summary>
        public virtual DateTime Date { get; set; }
    }
}
