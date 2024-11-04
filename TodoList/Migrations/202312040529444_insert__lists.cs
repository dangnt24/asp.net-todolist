namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insert__lists : DbMigration
    {
        public override void Up()
        {
            // LIST
            Sql("INSERT INTO Lists(ListName, BgColor, Email, CreatedAt, Deleted) VALUES ('None', '#ccc', 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO Lists(ListName, BgColor, Email, CreatedAt, Deleted) VALUES ('Work', '#66d9e8', 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO Lists(ListName, BgColor, Email, CreatedAt, Deleted) VALUES ('Home Work', '#ff6b6b', 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO Lists(ListName, BgColor, Email, CreatedAt, Deleted) VALUES ('Go to School', '#da77f2', 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
