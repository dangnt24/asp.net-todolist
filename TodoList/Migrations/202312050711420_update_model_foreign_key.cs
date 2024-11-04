namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_model_foreign_key : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lists", "Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.StickyWalls", "Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tasks", "Email", c => c.String(maxLength: 128));
            CreateIndex("dbo.Lists", "Email");
            CreateIndex("dbo.StickyWalls", "Email");
            CreateIndex("dbo.SubTasks", "TaskID");
            CreateIndex("dbo.Tasks", "ListID");
            CreateIndex("dbo.Tasks", "Email");
            //AddForeignKey("dbo.Lists", "Email", "dbo.Accounts", "Email");
            //AddForeignKey("dbo.StickyWalls", "Email", "dbo.Accounts", "Email");
            //AddForeignKey("dbo.Tasks", "Email", "dbo.Accounts", "Email");
            //AddForeignKey("dbo.Tasks", "ListID", "dbo.Lists", "ListID", cascadeDelete: true);
            //AddForeignKey("dbo.SubTasks", "TaskID", "dbo.Tasks", "TaskID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubTasks", "TaskID", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "ListID", "dbo.Lists");
            DropForeignKey("dbo.Tasks", "Email", "dbo.Accounts");
            DropForeignKey("dbo.StickyWalls", "Email", "dbo.Accounts");
            DropForeignKey("dbo.Lists", "Email", "dbo.Accounts");
            DropIndex("dbo.Tasks", new[] { "Email" });
            DropIndex("dbo.Tasks", new[] { "ListID" });
            DropIndex("dbo.SubTasks", new[] { "TaskID" });
            DropIndex("dbo.StickyWalls", new[] { "Email" });
            DropIndex("dbo.Lists", new[] { "Email" });
            AlterColumn("dbo.Tasks", "Email", c => c.String());
            AlterColumn("dbo.StickyWalls", "Email", c => c.String());
            AlterColumn("dbo.Lists", "Email", c => c.String());
        }
    }
}
