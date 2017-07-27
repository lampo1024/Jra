using System.Web.Http;
using Jra.Admin.InstanceFactory.ServiceFactory;
using Jra.Mapping;
using Jra.Services;

namespace Jra.Admin.Controllers.V1
{
    public class DemoController : ApiController
    {
        private readonly OnlineUserService _onlineUserService;
        public DemoController()
        {
            _onlineUserService = AllServicesFactory.CreateServiceInstance<OnlineUserService>();
        }
        [HttpGet]
        public IHttpActionResult UserInfo()
        {
            return Ok(ContextWork.CurrentUser.User);
        }

        [HttpGet]
        public IHttpActionResult Find()
        {
            var onlineUser = _onlineUserService.FindById(1).ToViewModel();
            return Ok(onlineUser);
        }
    }
}
