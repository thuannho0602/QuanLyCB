using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace CBBApplication
{
    public static class PrincipalExtensions
    {
        public static string FullName(this ISession session)
        {
            string token = session.GetString("UserToken");
            if (!string.IsNullOrEmpty(token))
            {
                var jwttoken = new JwtSecurityTokenHandler().ReadJwtToken(token);

                var jti = jwttoken.Claims.First(claim => claim.Type == "given_name").Value;
                return jti;
            }
            return "";
        }
    }
}
