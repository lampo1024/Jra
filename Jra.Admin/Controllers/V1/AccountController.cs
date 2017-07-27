using System.Web.Http;
using System.Web.Security;
using Jra.Admin.Models;
using Jra.Admin.ViewModel.Account;
using Newtonsoft.Json;

namespace Jra.Admin.Controllers.V1
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login(LoginViewModel model)
        {
            var userInfo = new UserInfoModel
            {
                DisplayName = "Admin",
                EmailAddress = "test@example.com",
                Id = 1,
                LoginName = model.UserName,
                Type = -1
            };
            var cookieUser = JsonConvert.SerializeObject(userInfo);
            FormsAuthentication.SetAuthCookie(cookieUser, true);
            var response = InstanceFactory.ResponseModelFactory.CreateResponseModel("登录成功");
            return Ok(response);
        }
    }
}
