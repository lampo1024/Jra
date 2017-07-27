using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Jra.Admin
{
    public class CustomExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //var response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
            //{
            //    Content = new StringContent("An unhandled exception was thrown by server."),
            //    ReasonPhrase = "Internal Server Error. Please contact your administrator."
            //};
            //actionExecutedContext.Response = response;

            var exception = actionExecutedContext.Exception as ApiException;
            if (exception != null)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
                    exception.StatusCode, exception.Message);
            }
            else
            {
                //actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,new ApiException(HttpStatusCode.InternalServerError, "An unexpected error occured"));
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                        new HttpError(actionExecutedContext.Exception.Message));
                //new HttpError("服务器忙,请稍候再试..."));
            }
        }
    }
}