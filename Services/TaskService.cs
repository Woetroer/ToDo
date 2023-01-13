﻿using Todo.Data;
using Task = Todo.Models.Task;

namespace Todo.Services
{
    public class TaskService
    {
        public delegate void TasksChanged(List<Task> tasks);
        public static event TasksChanged OnTasksChanged;
        private readonly TaskContext db = new();
        public void Add(Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
            OnTasksChanged?.Invoke(db.Tasks.ToList());
        }

        public void Delete(int id)
        {
            db.Tasks.Remove(db.Tasks.Single(task => task.Id == id));
            db.SaveChanges();
            OnTasksChanged?.Invoke(db.Tasks.ToList());
        }

        public bool IsDuplicate(Task taskToAdd)
        {
            var duplicates = db.Tasks.Where(task => task.Title == taskToAdd.Title);
            if (duplicates.Count() > 0) return true;
            return false;
        }
    }
}
