using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data
{
    public class SectionDto
    {
        [Key]
        public int SectionId { get; set; }
        public string NameSection { get; set; }
        public string DecriptionSection { get; set; }
        public string OwnerSection { get; set; }
        public List<PageDto> PagesOfSection { get; set; }

    }
}
