using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using System.Configuration;
using System.Data;

namespace Jra.Services
{
    /// <summary>
    /// 数据库连接工厂
    /// </summary>
   public class DbConnectionFactory
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected static string ConnectionString { get; set; }

        /// <summary>
        /// 数据库连接工厂构造器
        /// </summary>
        static DbConnectionFactory()
        {
            OrmLiteConfig.DialectProvider = SqlServerDialect.Provider;
            ConnectionString = ConfigurationManager.ConnectionStrings["SQLSERVER"].ConnectionString;
        }

        /// <summary>
        /// 获取数据库连接的实例
        /// </summary>
        /// <param name="connString">数据库连接字符串</param>
        /// <returns></returns>
        public static IDbConnection GetDbConnection(string connString = null)
        {
            connString = connString ?? ConnectionString;
            return connString.OpenDbConnection();
        }
    }
}
