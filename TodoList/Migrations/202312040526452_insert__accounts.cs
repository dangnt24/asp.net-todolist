namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insert__accounts : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Accounts(Email, Password, CreatedAt, Deleted) VALUES ('tester@gmail.com', '202cb962ac59075b964b07152d234b70', CURRENT_TIMESTAMP, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
