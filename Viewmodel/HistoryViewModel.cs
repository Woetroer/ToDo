using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Todo.Data;
using Todo.Services;
using Task = Todo.Models.Task;

namespace Todo.Viewmodel
{
    public partial class HistoryViewModel : ObservableObject
    {
        readonly TaskService taskService = new();
        public HistoryViewModel()
        {
            TaskService.OnTasksChanged += RefreshLibrary;
            RefreshLibrary();
        }

        public void RefreshLibrary(List<Task> tasks = null)
        {
            using var db = new TaskContext();
            Tasks = new ObservableCollection<Task>(db.Tasks.Where(task => task.IsCompleted == true).OrderByDescending(task => task.Id));
        }

        [ObservableProperty]
        ObservableCollection<Task> tasks;

        [RelayCommand]
        public void DeleteTask(Task task) => taskService.Delete(task);

        [RelayCommand]
        public void DeleteHistory() => taskService.DeleteHistory();
    }
}
