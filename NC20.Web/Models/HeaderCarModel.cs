using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC20.Web.Models
{
    public class HeaderCarModel
    {
        public int Id { get; set; }
        public ImageModel Image { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
    }
}
