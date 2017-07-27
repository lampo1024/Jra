using System;

namespace Jra.Admin.Models
{
    [Serializable]
    public class UserInfoModel
    {
        public UserInfoModel()
        {
            LoginName = "Unknown";
            DisplayName = "Unknown";
            EmailAddress = "Unknown";
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 用户类型[-1:超级管理员,0:一般用户]
        /// </summary>
        public int Type { get; set; }
    }
}