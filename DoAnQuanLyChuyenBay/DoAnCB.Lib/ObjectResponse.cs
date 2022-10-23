using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnCB.Lib
{
    public class ObjectResponse : IResponse
    {
        [JsonIgnore]
        public int __Id { get; set; }
        public virtual int StatusCode { get; set; } = StatusCodes.Status200OK;
    }
}
