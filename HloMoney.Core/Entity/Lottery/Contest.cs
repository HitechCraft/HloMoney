namespace HloMoney.Core.Entity
{   
    using Base;

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
    }
}
