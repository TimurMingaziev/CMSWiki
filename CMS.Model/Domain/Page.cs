using System;
using System.Collections.Generic;

namespace CMS.Model.Domain
{
    public class Page
    {
        public Page()
        {
        //    PagesThis = new List<Page>();
            Comments = new List<Comment>();
            Marks = new List<Mark>();
        }

        public Page(string name, string content, DateTime datecreate,
            DateTime datechange, string owner, string changer, int sectionid)
        {

            NamePage = name;
            ContentPage = content;
            DateCreatePage = datecreate;
            DateChangePage = datechange;
            OwnerPage = owner;
            ChangerPage = changer;
            SectionId = sectionid;

        }

        public int PageId { get; set; }
        public string NamePage { get; set; }
        public string ContentPage { get; set; }
        public DateTime DateCreatePage { get; set; }
        public DateTime DateChangePage { get; set; }
        public string OwnerPage { get; set; }
        public string ChangerPage { get; set; }
        public int? SectionId { get; set; }
        public Section Section { get; set; }

      //  public virtual ICollection<Page> PagesThis { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }

        public void ChangePage(int id, Page page)
        {
            if (page.NamePage != "")
                NamePage = page.NamePage;
            if (page.ContentPage != "")
                ContentPage = page.ContentPage;
            if (page.ChangerPage != "")
                ChangerPage = page.ChangerPage;
            if (page.SectionId != 0)
                SectionId = page.SectionId;
        }
    }
}
