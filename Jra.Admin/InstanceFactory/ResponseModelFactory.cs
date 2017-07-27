using Jra.Admin.Models;

namespace Jra.Admin.InstanceFactory
{
    public class ResponseModelFactory
    {
        public static ResponseModel InstanceResponseModel
        {
            get { return new ResponseModel(); }
        }

        public static ResponseModel CreateResponseModel(string message = "", bool success = true)
        {
            return new ResponseModel
            {
                Message = message
            };
        }

        public static ResponseViewModel InstanceResponseViewModel
        {
            get { return new ResponseViewModel(); }
        }
    }
}