using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using Newtonsoft.Json;

namespace Jra.Admin
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private bool _required;
        public CustomAuthorizeAttribute(bool required = true)
        {
            _required = required;
        }
        public bool Required { get { return _required; } set { _required = value; } }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (!_required)
            {
                return;
            }
            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

            if (_required && !principal.Identity.IsAuthenticated)
            {
                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = "Unauthorized",
                    Content = new StringContent(JsonConvert.SerializeObject(new { success = false, message = "未授权的访问" }))
                };
                return;
            }
            if (!ContextWork.CurrentUser.IsSuperAdmin)
            {
                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    ReasonPhrase = "Unauthorized",
                    Content = new StringContent(JsonConvert.SerializeObject(new { success = false, message = "权限级别不足" }))
                };
                return;
            }
            base.OnAuthorization(actionContext);
        }

        #region Overrides of AuthorizeAttribute

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Forbidden,
                Content = new StringContent("Unauthorized")
            };
        }

        #endregion
    }
}