namespace CMS.Model.Domain
{
    public class Comment
    {
        public Comment() { }
        public Comment(string content, string owner, int pageid)
        {
            ContentComment = content;
            OwnerComment = owner;
            PageId = pageid;

        }
        public int CommentId { get; set; }
        public string ContentComment { get; set; }
        public string OwnerComment { get; set; }

        public int PageId { get; set; }
        public virtual Page Page { get; set; }

    }
}
