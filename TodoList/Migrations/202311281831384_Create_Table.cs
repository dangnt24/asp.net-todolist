namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: true),
                        Deleted = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListID = c.Int(nullable: false, identity: true),
                        ListName = c.String(),
                        Email = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: true),
                        Deleted = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ListID)
                .ForeignKey("dbo.Accounts", t => t.Email, cascadeDelete: true);
            
            CreateTable(
                "dbo.StickyWalls",
                c => new
                    {
                        SwID = c.Int(nullable: false, identity: true),
                        SwTitle = c.String(),
                        SwDescription = c.String(),
                        Email = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: true),
                        Deleted = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.SwID)
                .ForeignKey("dbo.Accounts", t => t.Email, cascadeDelete: true);
            
            CreateTable(
                "dbo.SubTasks",
                c => new
                    {
                        StID = c.Int(nullable: false, identity: true),
                        StTitle = c.String(),
                        StDescription = c.String(),
                        StImage = c.String(),
                        DueDate = c.DateTime(),
                        TaskID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StID)
                .ForeignKey("dbo.Tasks", t => t.TaskID, cascadeDelete: true);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        TaskTitle = c.String(),
                        TaskDescription = c.String(),
                        TaskImage = c.String(),
                        Upcoming = c.String(),
                        DueDate = c.DateTime(),
                        ListID = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: true),
                        Deleted = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.Lists", t => t.ListID)
                .ForeignKey("dbo.Accounts", t => t.Email);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tasks");
            DropTable("dbo.SubTasks");
            DropTable("dbo.StickyWalls");
            DropTable("dbo.Lists");
            DropTable("dbo.Accounts");
        }
    }
}
