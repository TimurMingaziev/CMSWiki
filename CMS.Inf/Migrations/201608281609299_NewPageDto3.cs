namespace CMS.Inf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPageDto3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pages", "PageDto_PageId", "dbo.Pages");
            DropIndex("dbo.Pages", new[] { "PageDto_PageId" });
            DropColumn("dbo.Pages", "PageDto_PageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "PageDto_PageId", c => c.Int());
            CreateIndex("dbo.Pages", "PageDto_PageId");
            AddForeignKey("dbo.Pages", "PageDto_PageId", "dbo.Pages", "PageId");
        }
    }
}
