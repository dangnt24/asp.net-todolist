namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_updartedAt_as_nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Lists", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.StickyWalls", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Tasks", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StickyWalls", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Lists", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Accounts", "UpdatedAt", c => c.DateTime(nullable: false));
        }
    }
}
