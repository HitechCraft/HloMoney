namespace HloMoney.Core.Entity
{
    #region Using Directives

    using Base;
    using System;
    using Models.Enum;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Main system Entity
    /// </summary>
    public class Contest : BaseEntity<Contest>
    {
        /// <summary>
        /// Contest description
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gift, that shoukd be given to winner
        /// </summary>
        public virtual string Gift { get; set; }

        /// <summary>
        /// Contest image, such in vk group
        /// </summary>
        public virtual byte[] Image { get; set; }

        /// <summary>
        /// Contest winner count
        /// </summary>
        public virtual int WinnerCount { get; set; }

        /// <summary>
        /// Contest type
        /// </summary>
        public virtual ContestType Type { get; set; }

        /// <summary>
        /// Contest current status
        /// </summary>
        public virtual ContestStatus Status { get; set; }

        /// <summary>
        /// Time, when contest will be start
        /// </summary>
        public virtual DateTime? StartTime { get; set; }

        /// <summary>
        /// Time, when contest will be finish
        /// </summary>
        public virtual DateTime? EndTime { get; set; }

        /// <summary>
        /// Contest time increment
        /// </summary>
        public virtual TimeIncrement Increment { get; set; }

        /// <summary>
        /// Parts of this contest
        /// </summary>
        public virtual ISet<ContestPart> Parts { get; set; }

        /// <summary>
        /// Comments of this contest
        /// </summary>
        public virtual ISet<Comment> Comments { get; set; }
    }
}
