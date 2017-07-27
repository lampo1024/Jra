namespace Jra.ViewModel
{
    public class OnlineUserViewModel
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 全局GUID
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public string LoginDate { get; set; }
        /// <summary>
        /// 登录时的IP地址
        /// </summary>
        public string IpAddress { get; set; }
    }
}
