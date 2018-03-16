using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NC20.Entities
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(256)]
        public string Url { get; set; }
        [MaxLength(256)]
        public string FileKey { get; set; }
    }
}
