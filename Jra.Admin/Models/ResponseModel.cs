using Jra.Core;

namespace Jra.Admin.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            Success = true;
            Message = "操作成功";
            Status = true;
            _type = "";
        }
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 请求是否成功
        /// </summary>
        public bool Status { get; set; }

        private string _type;
        public string Type
        {
            get
            {
                if (_type != "") return _type;
                _type = MessageType.SUCCESS;
                if (!Success || !Status)
                {
                    _type = MessageType.ERROR;
                }
                return _type;
            }
            set { _type = value; }
        }
    }
}