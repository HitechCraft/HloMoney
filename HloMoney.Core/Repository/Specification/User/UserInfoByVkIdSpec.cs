namespace HloMoney.Core.Repository.Specification.User
{
    #region Using Directives

    using System;
    using System.Linq.Expressions;
    using Entity;

    #endregion

    public class UserInfoByVkIdSpec : BaseSpecification<UserInfo>
    {
        #region Private Fields

        private readonly string _vkId;

        #endregion

        #region Constructor

        public UserInfoByVkIdSpec(string vkId)
        {
            this._vkId = vkId;
        }

        #endregion

        #region Expression

        public override Expression<Func<UserInfo, bool>> IsSatisfiedBy()
        {
            return userInfo => userInfo.VkId == this._vkId;
        }

        #endregion
    }
}
