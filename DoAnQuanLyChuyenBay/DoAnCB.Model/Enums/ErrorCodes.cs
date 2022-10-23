using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Model.Enums
{
    public enum ErrorCodes
    {
        [Description("Success")]
        Success = 0,

        [Description("Bad Request")]
        BadRequest = 1,

        [Description("Invalid Model")]
        InvalidModel = 2,

        [Description("Not Found")]
        NotFound = 3,

        [Description("Internal Server Error")]
        InternalServerError = 4
    }
}
