namespace Jra.Core.Extensions.Auth
{
    public static class UserExtension
    {
        /// <summary>
        /// 当前用户是否为超级管理员
        /// </summary>
        /// <param name="userType">用户类型</param>
        /// <returns></returns>
        public static bool IsSuperAdministrator(this int userType)
        {
            return userType == -1;
        }

        /// <summary>
        /// 当前用户是否为超级管理员
        /// </summary>
        /// <param name="userType">用户类型的枚举值</param>
        /// <returns></returns>
        public static bool IsSuperAdministrator(this UserType userType)
        {
            return userType == UserType.Super;
        }

    }
}
