using NC20.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NC20.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string DisplayName { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<RoleClaim> RoleClaims { get; set; }
    }
}
