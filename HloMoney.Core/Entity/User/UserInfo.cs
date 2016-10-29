namespace HloMoney.Core.Entity
{
    using Base;
    using System;

    /// <summary>
    /// Entity with user info
    /// </summary>
    public class UserInfo : BaseEntity<UserInfo>
    {
        /// <summary>
        /// Vkontakte user id
        /// </summary>
        public virtual string VkId { get; set; }
        /// <summary>
        /// Use first Name
        /// </summary>
        public virtual string FirstName { get; set; }
        /// <summary>
        /// Use last Name
        /// </summary>
        public virtual string LastName { get; set; }
        /// <summary>
        /// User avatar
        /// </summary>
        public virtual byte[] Avatar { get; set; }
        /// <summary>
        /// User birth date
        /// </summary>
        public virtual DateTime? BirthDate { get; set; }
        /// <summary>
        /// Synchronize this info with info in vk?
        /// </summary>
        public virtual bool IsSynchron { get; set; }
        /// <summary>
        /// Last info update
        /// </summary>
        public virtual DateTime LastUpdate { get; set; }
    }
}
