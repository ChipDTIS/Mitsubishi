using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC20.Web.Models
{
    public class RoleClaimModel
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? ClaimId { get; set; }
        public ClaimModel Claim { get; set; }
        public RoleModel Role { get; set; }
    }
}
