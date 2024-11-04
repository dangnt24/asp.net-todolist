namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insert__tasks : DbMigration
    {
        public override void Up()
        {
            //TASK
            Sql("INSERT INTO Tasks(TaskTitle, TaskDescription, Upcoming, ListID, Email, CreatedAt, Deleted) VALUES ('Create a database of To Do List', 'Description', 'today', 2, 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO Tasks(TaskTitle, TaskDescription, Upcoming, ListID, Email, CreatedAt, Deleted) VALUES ('Desgin layout pages', 'Description', 'today', 2, 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO Tasks(TaskTitle, TaskDescription, Upcoming, ListID, Email, CreatedAt, Deleted) VALUES ('Create models, views, controllers and coding', 'Description', 'today', 2, 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO Tasks(TaskTitle, TaskDescription, Upcoming, ListID, Email, CreatedAt, Deleted) VALUES ('Deployment and testing app', 'Description', 'today', 2, 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");

            Sql("INSERT INTO Tasks(TaskTitle, TaskDescription, Upcoming, ListID, Email, CreatedAt, Deleted) VALUES ('Review lessons', 'Description', 'tomorrow', 3, 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO Tasks(TaskTitle, TaskDescription, Upcoming, ListID, Email, CreatedAt, Deleted) VALUES ('Write the lesson', 'Description', 'tomorrow', 3, 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO Tasks(TaskTitle, TaskDescription, Upcoming, ListID, Email, CreatedAt, Deleted) VALUES ('Go home', 'Description', 'tomorrow', 3, 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO Tasks(TaskTitle, TaskDescription, Upcoming, ListID, Email, CreatedAt, Deleted) VALUES ('Do homework', 'Description', 'tomorrow', 3, 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");

            Sql("INSERT INTO Tasks(TaskTitle, TaskDescription, Upcoming, ListID, Email, CreatedAt, Deleted) VALUES ('Sweep the floor', 'Description', 'thisweek', 4, 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO Tasks(TaskTitle, TaskDescription, Upcoming, ListID, Email, CreatedAt, Deleted) VALUES ('Wash the dishes', 'Description', 'thisweek', 4, 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO Tasks(TaskTitle, TaskDescription, Upcoming, ListID, Email, CreatedAt, Deleted) VALUES ('Do the laundry', 'Description', 'thisweek', 4, 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
            Sql("INSERT INTO Tasks(TaskTitle, TaskDescription, Upcoming, ListID, Email, CreatedAt, Deleted) VALUES ('Do the cooking', 'Description', 'thisweek', 4, 'tester@gmail.com', CURRENT_TIMESTAMP, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
