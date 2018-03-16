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
        public static ImageModel ToModel(Image entity)
        {
            if (entity == null) return null;
            var imageUrl = entity.Url;
            if (!string.IsNullOrEmpty(entity.FileKey))
            {
                imageUrl = string.Format("https://s3-ap-southeast-1.amazonaws.com/dfwresource/{0}", entity.FileKey);
            }
            return entity == null ? null : new ImageModel()
            {
                Id = entity.Id,
                Url = imageUrl
            };
        }

        public static List<ImageModel> ToModel(IEnumerable<Image> entities)
        {
            return entities == null ? null : entities.Select(ToModel).ToList();
        }
    }
}
