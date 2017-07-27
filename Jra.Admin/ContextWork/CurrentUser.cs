using System;
using Jra.Core.Extensions.Auth;
using System.Web;
using Jra.Admin.Models;
using Newtonsoft.Json;

namespace Jra.Admin.ContextWork
{
    /// <summary>
    /// 当前登录用户信息静态类
    /// </summary>
    public static class CurrentUser
    {
        /// <summary>
        /// 用户实体对象
        /// </summary>
        public static UserInfoModel User
        {
            get
            {
                var model = new UserInfoModel();
                try
                {
                    if (IsLogin)
                    {
                        var data = HttpContext.Current.User.Identity.Name;
                        var userInfoModel = JsonConvert.DeserializeObject<UserInfoModel>(data);
                        return userInfoModel;
                    }
                }
                catch (Exception exception)
                {

                }
                return model;
            }
        }

        /// <summary>
        /// 获取当前用户登录名
        /// </summary>
        public static string LoginName
        {
            get { return User.LoginName; }
        }
        /// <summary>
        /// 获取当前用户ID
        /// </summary>
        public static int Id
        {
            get { return User.Id; }
        }

        /// <summary>
        /// 获取当前用户显示名
        /// </summary>
        public static string DisplayName
        {
            get { return User.DisplayName; }
        }

        /// <summary>
        /// 获取当前用户邮箱地址
        /// </summary>
        public static string EmailAddress
        {
            get { return User.EmailAddress; }
        }

        /// <summary>
        /// 用户类型[-1:超级管理员,0:一般用户]
        /// </summary>
        public static int Type
        {
            get { return User.Type; }
        }
        /// <summary>
        /// 判断当前用户是否登录
        /// </summary>
        public static bool IsLogin => HttpContext.Current.Request.IsAuthenticated;

        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        public static bool IsSuperAdmin
        {
            get { return Type.IsSuperAdministrator(); }
        }
    }
}