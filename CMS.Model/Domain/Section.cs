using System.Collections.Generic;

namespace CMS.Model.Domain
{
    public class Section
    {
        public Section() {
            PagesOfSection = new List<Page>();
        }
        public Section(string name, string decr, string owner)
        {
            NameSection = name;
            DecriptionSection = decr;
            OwnerSection = owner;
        }

        public int SectionId { get; set; }
        public string NameSection { get; set; }
        public string DecriptionSection { get; set; }
        public string OwnerSection { get; set; }
        public virtual ICollection<Page> PagesOfSection { get; set; }
    }
}
