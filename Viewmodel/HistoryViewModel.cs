using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Todo.Data;
using Todo.Services;
using Task = Todo.Models.Task;

namespace Todo.Viewmodel
{
    public partial class HistoryViewModel : ObservableObject
    {
        readonly TaskService taskService = new();
        private readonly TaskContext db = new();
        public HistoryViewModel()
        {
            TaskService.OnTasksChanged += RefreshLibrary;
            RefreshLibrary();
        }

        public void RefreshLibrary(List<Task> tasks = null) => Tasks = new ObservableCollection<Task>(db.Tasks);

        [ObservableProperty]
        ObservableCollection<Task> tasks;
    }
}
