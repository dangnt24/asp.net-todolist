namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_done : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Done", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Done");
        }
    }
}
