using System.Collections.Generic;

namespace HloMoney.Core.Entity
{   
    using Base;
    using Models.Enum;
    using System;

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
        /// Count of winners, that system should selects
        /// </summary>
        public virtual int Winners { get; set; }

        /// <summary>
        /// Cotest Type
        /// </summary>
        public virtual ContestType Type { get; set; }

        /// <summary>
        /// Contest status for system, it may be new/started/ended
        /// </summary>
        public virtual ContestStatus Status { get; set; }

        /// <summary>
        /// Time, when contest will be start
        /// </summary>
        public virtual DateTime StartTime { get; set; }

        /// <summary>
        /// Time? when contest will be end
        /// </summary>
        public virtual DateTime EndTime { get; set; }

        /// <summary>
        /// Parts of this contest
        /// </summary>
        public virtual ISet<ContestPart> Parts { get; set; }
    }
}
