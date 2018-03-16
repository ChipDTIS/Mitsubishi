using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC20.Web.Models
{
    public class UserLoginTokenModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime LastLoginDated { get; set; }
        public DateTime ExpiredDated { get; set; }
        public bool? IsRememberMe { get; set; }
        public UserModel User { get; set; }
    }
}
