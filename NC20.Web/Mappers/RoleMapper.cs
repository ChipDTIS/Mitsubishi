using NC20.Entities;
using NC20.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC20.Web.Mappers
{
    public partial class Mapper
    {
        public static RoleModel ToModel(Role entity)
        {
            return entity == null ? null : new RoleModel()
            {
                Id = entity.Id,
                DisplayName = entity.DisplayName,
                Name = entity.Name
            };
        }

        public static List<RoleModel> ToModel(IEnumerable<Role> entities)
        {
            return entities == null ? null : entities.Select(ToModel).ToList();
        }
    }
}
