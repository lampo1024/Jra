using System;
using System.Web;
using Jra.Mapping;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Jra.Frontend
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterAutoMapper();
        }
        /// <summary>
        /// set response header with apache
        /// </summary>
        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Set("Server", "Apache");
        }

        /// <summary>
        /// handle application error
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event argument</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Server.ClearError();
            var message = exception.ToString();

            var httpException = exception as HttpException;
            if (httpException == null) return;

            var statusCode = httpException.GetHttpCode();
            switch (statusCode)
            {
                case 404:
                    Response.Redirect("~/404");
                    break;
                case 500:
                    Response.Redirect("~/error");
                    break;
            }
        }

        /// <summary>
        /// register automapper
        /// </summary>
        private static void RegisterAutoMapper()
        {
            new AutoMapperStartupTask().Execute();
        }
    }
}
