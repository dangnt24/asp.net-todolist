namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_default_column : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Accounts ADD CONSTRAINT DF_Accounts_CreatedAt DEFAULT CURRENT_TIMESTAMP FOR CreatedAt;");
            Sql("ALTER TABLE Accounts ADD CONSTRAINT DF_Accounts_Deleted DEFAULT 0 FOR Deleted;");
            Sql("ALTER TABLE Lists ADD CONSTRAINT DF_Lists_CreatedAt DEFAULT CURRENT_TIMESTAMP FOR CreatedAt;");
            Sql("ALTER TABLE Lists ADD CONSTRAINT DF_Lists_Deleted DEFAULT 0 FOR Deleted;");
            Sql("ALTER TABLE Tasks ADD CONSTRAINT DF_Tasks_CreatedAt DEFAULT CURRENT_TIMESTAMP FOR CreatedAt;");
            Sql("ALTER TABLE Tasks ADD CONSTRAINT DF_Tasks_Deleted DEFAULT 0 FOR Deleted;");
            Sql("ALTER TABLE StickyWalls ADD CONSTRAINT DF_StickyWalls_CreatedAt DEFAULT CURRENT_TIMESTAMP FOR CreatedAt;");
            Sql("ALTER TABLE StickyWalls ADD CONSTRAINT DF_StickyWalls_Deleted DEFAULT 0 FOR Deleted;");
        }
        
        public override void Down()
        {
        }
    }
}
