using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NC20.Entities
{
    public class UserLoginToken
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [MaxLength(256)]
        public string Token { get; set; }
        public DateTime LastLoginDated { get; set; }
        public DateTime ExpiredDated { get; set; }
        public bool? IsRememberMe { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
