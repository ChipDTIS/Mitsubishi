using NC20.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NC20.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(256)]
        public string UserName { get; set; }
        [MaxLength(256)]
        public string Password { get; set; }
        public eUserStatus? Status { get; set; }
        [MaxLength(256)]
        public string ProviderKey { get; set; }
        [MaxLength(256)]
        public string ProviderName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public List<UserRole> UserRoles { get; set; }
        public List<UserProfile> UserProfiles { get; set; }
        public List<UserLoginToken> UserLoginTokens { get; set; }

    }
}
