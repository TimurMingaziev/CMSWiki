using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data
{
    public class MarkDto
    {
        [Key]
        public int MarkId { get; set; }
        public int MarkThis { get; set; }
        public string OwnerMark { get; set; }
        public DateTime DateMark { get; set; }
        public int PageId { get; set; }
    }
}
