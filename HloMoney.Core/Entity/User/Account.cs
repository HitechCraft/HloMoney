namespace HloMoney.Core.Entity
{
    #region Using Directives

    using Base;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// User Entity
    /// </summary>
    public class Account : BaseEntity<Account>
    {
        /// <summary>
        /// User Vk Id
        /// </summary>
        public virtual string UserId { get; set; }
        
        /// <summary>
        /// User Name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// User parts list
        /// </summary>
        public virtual ISet<ContestPart> Parts { get; set; }
    }
}
