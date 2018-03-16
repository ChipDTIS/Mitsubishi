using NC20.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC20.Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public eUserStatus? Status { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<UserRoleModel> UserRoles { get; set; }
        public List<UserProfileModel> UserProfiles { get; set; }
        public List<UserLoginTokenModel> UserLoginTokens { get; set; }
    }
}
