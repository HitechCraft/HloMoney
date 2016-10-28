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
        /// Use Name
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// User avatar
        /// </summary>
        public virtual byte[] Avatar { get; set; }
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
