namespace CMS.Inf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMarkCommentDto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Marks", "PageId", "dbo.Pages");
            DropIndex("dbo.Comments", new[] { "PageId" });
            DropIndex("dbo.Marks", new[] { "PageId" });
            AlterColumn("dbo.Comments", "PageId", c => c.Int(nullable: false));
            AlterColumn("dbo.Marks", "PageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "PageId");
            CreateIndex("dbo.Marks", "PageId");
            AddForeignKey("dbo.Comments", "PageId", "dbo.Pages", "PageId", cascadeDelete: true);
            AddForeignKey("dbo.Marks", "PageId", "dbo.Pages", "PageId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Comments", "PageId", "dbo.Pages");
            DropIndex("dbo.Marks", new[] { "PageId" });
            DropIndex("dbo.Comments", new[] { "PageId" });
            AlterColumn("dbo.Marks", "PageId", c => c.Int());
            AlterColumn("dbo.Comments", "PageId", c => c.Int());
            CreateIndex("dbo.Marks", "PageId");
            CreateIndex("dbo.Comments", "PageId");
            AddForeignKey("dbo.Marks", "PageId", "dbo.Pages", "PageId");
            AddForeignKey("dbo.Comments", "PageId", "dbo.Pages", "PageId");
        }
    }
}
