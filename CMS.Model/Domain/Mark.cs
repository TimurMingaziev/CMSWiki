using System;

namespace CMS.Model.Domain
{
    public class Mark
    {
        public Mark() { }
        public Mark(int mark, string owner, DateTime date, int pageid)
        {
            if (mark == 1 || mark == -1)
                MarkThis = mark;
            else
                MarkThis = 0;
            OwnerMark = owner;
            DateMark = date;
            PageId = pageid;
        }

        public int MarkId { get; set; }
        public int MarkThis { get; set; }
        public string OwnerMark { get; set; }
        public DateTime DateMark { get; set; }

        public int? PageId { get; set; }
        public virtual Page Page { get; set; }
        
        
    }
}
