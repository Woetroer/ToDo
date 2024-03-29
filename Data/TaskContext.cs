﻿using Microsoft.EntityFrameworkCore;
using Task = Todo.Models.Task;


namespace Todo.Data
{
    class TaskContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public string DbPath { get; }

        public TaskContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Todoo.db");
            Database.EnsureCreated();
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
