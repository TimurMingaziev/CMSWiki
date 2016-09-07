using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data
{
    public class PageDto
    {
        [Key]
        public int PageId { get; set; }
        public string NamePage { get; set; }
        public string ContentPage { get; set; }
        public DateTime DateCreatePage { get; set; }
        public DateTime DateChangePage { get; set; }
        public string OwnerPage { get; set; }
        public string ChangerPage { get; set; }
        public  int SectionId { get; set; }
        
  //      public virtual ICollection<PageDto> PagesThis { get; set; }
        public  List<CommentDto> Comments { get; set; }
        public  List<MarkDto> Marks { get; set; }

    }
}
