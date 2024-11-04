namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insert__sticky_walls : DbMigration
    {
        public override void Up()
        {
            //STICKY WALL
            Sql("INSERT INTO StickyWalls(SwTitle, SwDescription, BgColor, Email, CreatedAt, Deleted) VALUES ('Create Database', '- Create table\n- Create column\n- Insert data', '#fdf2b3', 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO StickyWalls(SwTitle, SwDescription, BgColor, Email, CreatedAt, Deleted) VALUES ('Design layout pages', '- Create login/register page\n- Create home page\n- Create the remaining components', '#d1eaed', 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO StickyWalls(SwTitle, SwDescription, BgColor, Email, CreatedAt, Deleted) VALUES ('Create model MVC', '- Create Models\n- Create views\n- Create Controller', '#ffdada', 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO StickyWalls(SwTitle, SwDescription, BgColor, Email, CreatedAt, Deleted) VALUES ('Deloyment and testing', '- Up source code to Azure\n- fix bugs (if any)', '#ffd4a9', 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
