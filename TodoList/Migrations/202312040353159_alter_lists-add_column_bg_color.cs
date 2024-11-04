namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_listsadd_column_bg_color : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lists", "BgColor", c => c.String());
            AddColumn("dbo.StickyWalls", "BgColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StickyWalls", "BgColor");
            DropColumn("dbo.Lists", "BgColor");
        }
    }
}
