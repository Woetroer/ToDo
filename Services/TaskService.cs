using Todo.Data;
using Task = Todo.Models.Task;

namespace Todo.Services
{
    public class TaskService
    {
        public delegate void TasksChanged(List<Task> tasks);
        public static event TasksChanged OnTasksChanged;

        public void Add(Task task)
        {
            using var db = new TaskContext();
            db.Tasks.Add(task);
            db.SaveChanges();
            OnTasksChanged?.Invoke(db.Tasks.ToList());
        }

        public void Delete(Task task)
        {
            using var db = new TaskContext();
            db.Tasks.Remove(task);
            db.SaveChanges();
            OnTasksChanged?.Invoke(db.Tasks.ToList());
        }

        public void Complete(Task task)
        {
            string dateTime = DateTime.Now.ToString("MM/dd/yy");

            using var db = new TaskContext();
            task.IsCompleted = true;
            task.Title = $"{task.Title}" + "     " + $"({dateTime})";

            db.Update(task);
            db.SaveChanges();
            OnTasksChanged?.Invoke(db.Tasks.ToList());
        }

        public bool IsDuplicate(Task taskToAdd)
        {
            using var db = new TaskContext();
            var duplicates = db.Tasks.Where(task => task.Title == taskToAdd.Title);
            if (duplicates.Count() > 0) return true;
            return false;
        }

        public int TotalTasks()
        {
            using var db = new TaskContext();
            return db.Tasks.Where(task => task.IsCompleted == false).Count();
        }

        public void DeleteHistory()
        {
            using var db = new TaskContext();
            if (db.Tasks.Count() > 0)
            {
                foreach (Task task in db.Tasks)
                {
                    if (task.Title.Contains('('))
                    {
                        db.Tasks.Remove(task);
                    }
                }
                db.SaveChanges();
                OnTasksChanged?.Invoke(db.Tasks.ToList());
            }
        }
    }
}
