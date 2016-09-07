using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data
{
    public class CommentDto
    {
        [Key]
        public int CommentId { get; set; }
        public string ContentComment { get; set; }
        public string OwnerComment { get; set; }
        public int PageId { get; set; }
    }
}
