using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NC20.Web
{
    public class JwtHelper
    {
        public static readonly string jwtSecretKey = "CBPTSecretKey";
        public static string CreateJwtToken(string accessToken, DateTime expired)
        {
            var payload = new Dictionary<string, object>()
            {
                ["token"] = accessToken,
                ["exp"] = string.Format("{0:yyyyMMdd", expired)
            };
            var secretKey = Encoding.UTF8.GetBytes(jwtSecretKey);
            var token = JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);
            return token;
        }

        public static string Decode(string jwt)
        {
            var secretKey = Encoding.UTF8.GetBytes(jwtSecretKey);
            var json = JWT.Decode(jwt, secretKey);
            return json;
        }
    }
}
