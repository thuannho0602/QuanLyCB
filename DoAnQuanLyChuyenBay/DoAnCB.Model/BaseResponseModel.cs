using DoAnCB.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Model
{
    public class BaseResponseModel
    {
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }

    public class BaseResponseModel<T> : BaseResponseModel where T : class
    {
        public T Data { get; set; }
    }
}
