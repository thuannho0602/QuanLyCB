using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBApplication
{
    public static class SessionHelper
    {
        public static T GetComplexData<T>(this ISession session, string key)
        {
            var data = session.GetString(key)
;
            if (data == null)
            {
                return default;
            }
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static void SetComplexData(this ISession session, string key, string value)
        {
            session.SetString(key, value);
        }
    }
}
