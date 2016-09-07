namespace CMS.Inf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPageDto1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Marks", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Pages", "PageDto_PageId", "dbo.Pages");
            DropIndex("dbo.Comments", new[] { "PageId" });
            DropIndex("dbo.Marks", new[] { "PageId" });
            DropIndex("dbo.Pages", new[] { "PageDto_PageId" });
            DropColumn("dbo.Pages", "PageDto_PageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "PageDto_PageId", c => c.Int());
            CreateIndex("dbo.Pages", "PageDto_PageId");
            CreateIndex("dbo.Marks", "PageId");
            CreateIndex("dbo.Comments", "PageId");
            AddForeignKey("dbo.Pages", "PageDto_PageId", "dbo.Pages", "PageId");
            AddForeignKey("dbo.Marks", "PageId", "dbo.Pages", "PageId");
            AddForeignKey("dbo.Comments", "PageId", "dbo.Pages", "PageId");
        }
    }
}
