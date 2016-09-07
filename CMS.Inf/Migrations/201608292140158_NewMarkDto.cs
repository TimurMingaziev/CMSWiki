namespace CMS.Inf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMarkDto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Marks", "MarkThis", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Marks", "MarkThis", c => c.Short(nullable: false));
        }
    }
}
