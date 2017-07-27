namespace Jra.Core
{
    /// <summary>
    /// 系统用户类型
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        Super = -1,
        /// <summary>
        /// 一般用户
        /// </summary>
        User = 0
    }

    public class MessageType
    {
        /// <summary>
        /// 成功
        /// </summary>
        public static string SUCCESS = "success";
        /// <summary>
        /// 信息
        /// </summary>
        public static string INFO = "info";
        /// <summary>
        /// 警告
        /// </summary>
        public static string WARNING = "warning";
        /// <summary>
        /// 错误
        /// </summary>
        public static string ERROR = "error";

    }

}
