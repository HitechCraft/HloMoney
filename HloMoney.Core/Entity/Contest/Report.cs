namespace HloMoney.Core.Entity
{
    #region Using Directives

    using System;
    using Base;

    #endregion

    /// <summary>
    /// Entity for users reports
    /// </summary>
    public class Report : BaseEntity<Report>
    {
        /// <summary>
        /// Report title
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// Report text
        /// </summary>
        public virtual string Text { get; set; }
        /// <summary>
        /// User Vk id
        /// </summary>
        public virtual string AuthorId { get; set; }
        /// <summary>
        /// Report added date
        /// </summary>
        public virtual DateTime Date { get; set; }
    }
}
