using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnCB.Lib
{
    public interface IResponse
    {
        [JsonIgnore]
        int StatusCode { get; set; }
    }
}
