using Todo.Data;
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
    }
}
