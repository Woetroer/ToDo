using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Todo.Data;
using Todo.Services;
using Task = Todo.Models.Task;

namespace ToDo.Viewmodel;

public partial class MainViewModel : ObservableObject
{
    readonly TaskService taskService = new();
    private readonly TaskContext db = new();
    public MainViewModel()
    {
        TaskService.OnTasksChanged += RefreshLibrary;
        RefreshLibrary();
    }

    public void RefreshLibrary(List<Task> tasks = null) => Tasks = new ObservableCollection<Task>(db.Tasks.Where(task => !task.IsCompleted));

    [ObservableProperty]
    ObservableCollection<Task> tasks;

    [ObservableProperty]
    string text;

    [RelayCommand]
    void AddTask()
    {
        if (!string.IsNullOrWhiteSpace(text) && !taskService.IsDuplicate(new Task { Title = Text }))
        {
            taskService.Add(new Task { Title = text });
            text = string.Empty;
        }
    }

    [RelayCommand]
    public void CompleteTask(Task task) => taskService.Complete(task);
}
