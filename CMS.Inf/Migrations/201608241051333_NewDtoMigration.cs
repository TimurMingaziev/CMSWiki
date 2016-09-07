namespace CMS.Inf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDtoMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        ContentComment = c.String(),
                        OwnerComment = c.String(),
                        PageId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Pages", t => t.PageId)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        MarkId = c.Int(nullable: false, identity: true),
                        MarkThis = c.Short(nullable: false),
                        OwnerMark = c.String(),
                        DateMark = c.DateTime(nullable: false),
                        PageId = c.Int(),
                    })
                .PrimaryKey(t => t.MarkId)
                .ForeignKey("dbo.Pages", t => t.PageId)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        NamePage = c.String(),
                        ContentPage = c.String(),
                        DateCreatePage = c.DateTime(nullable: false),
                        DateChangePage = c.DateTime(nullable: false),
                        OwnerPage = c.String(),
                        ChangerPage = c.String(),
                        SectionId = c.Int(nullable: false),
                        PageDto_PageId = c.Int(),
                    })
                .PrimaryKey(t => t.PageId)
                .ForeignKey("dbo.Pages", t => t.PageDto_PageId)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId)
                .Index(t => t.PageDto_PageId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionId = c.Int(nullable: false, identity: true),
                        NameSection = c.String(),
                        DecriptionSection = c.String(),
                        OwnerSection = c.String(),
                    })
                .PrimaryKey(t => t.SectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Pages", "PageDto_PageId", "dbo.Pages");
            DropForeignKey("dbo.Marks", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Comments", "PageId", "dbo.Pages");
            DropIndex("dbo.Pages", new[] { "PageDto_PageId" });
            DropIndex("dbo.Pages", new[] { "SectionId" });
            DropIndex("dbo.Marks", new[] { "PageId" });
            DropIndex("dbo.Comments", new[] { "PageId" });
            DropTable("dbo.Sections");
            DropTable("dbo.Pages");
            DropTable("dbo.Marks");
            DropTable("dbo.Comments");
        }
    }
}
