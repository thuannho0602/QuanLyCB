using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBApplication.Models
{
    public class AccountLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AccountGoogleLogin
    {
        public string Token { get; set; }
    }

    public class AccountAzureLogin
    {
        public string Token { get; set; }
    }
}
