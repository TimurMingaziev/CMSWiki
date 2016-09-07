namespace CMS.Inf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPageDto2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "PageDto_PageId", c => c.Int());
            CreateIndex("dbo.Comments", "PageId");
            CreateIndex("dbo.Marks", "PageId");
            CreateIndex("dbo.Pages", "PageDto_PageId");
            AddForeignKey("dbo.Comments", "PageId", "dbo.Pages", "PageId");
            AddForeignKey("dbo.Marks", "PageId", "dbo.Pages", "PageId");
            AddForeignKey("dbo.Pages", "PageDto_PageId", "dbo.Pages", "PageId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "PageDto_PageId", "dbo.Pages");
            DropForeignKey("dbo.Marks", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Comments", "PageId", "dbo.Pages");
            DropIndex("dbo.Pages", new[] { "PageDto_PageId" });
            DropIndex("dbo.Marks", new[] { "PageId" });
            DropIndex("dbo.Comments", new[] { "PageId" });
            DropColumn("dbo.Pages", "PageDto_PageId");
        }
    }
}
