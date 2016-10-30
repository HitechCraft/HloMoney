﻿namespace HloMoney.Core.Entity
{
    using Base;

    /// <summary>
    /// Entity that get info of contest time incr. for some condition
    /// </summary>
    public class TimeIncrement : BaseEntity<TimeIncrement>
    {
        /// <summary>
        /// The contest
        /// </summary>
        public virtual Contest Contest { get; set; }
        /// <summary>
        /// Time increment value (seconds)
        /// </summary>
        public virtual float Increment { get; set; }
    }
}