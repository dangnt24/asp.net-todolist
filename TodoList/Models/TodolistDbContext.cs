using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class TodolistDbContext: DbContext
    {
        public TodolistDbContext(): base("conn")
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<StickyWall> StickyWalls { get; set; }
    }
}