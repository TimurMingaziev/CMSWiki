using System.Data.Common;
using System.Data.Entity;
using CMS.Data;
using CMS.Model;
using MySql.Data.Entity;

namespace CMS.Inf
{

    public class UserContext : DbContext
    {
    
        public UserContext()
            : base("UserContext")
        {
            
        }

        // Constructor to use on a DbConnection that is already opened
        public UserContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }
        public DbSet<SectionDto> Section { get; set; }
        public DbSet<PageDto> Page { get; set; }
        public DbSet<MarkDto> Mark { get; set; }
        public DbSet<CommentDto> Comment { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SectionDto>().ToTable("Sections");
            modelBuilder.Entity<PageDto>().ToTable("Pages");
            modelBuilder.Entity<MarkDto>().ToTable("Marks");
            modelBuilder.Entity<CommentDto>().ToTable("Comments");
        }
    }
}
