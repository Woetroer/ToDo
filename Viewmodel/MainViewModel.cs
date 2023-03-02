using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Todo.Data;
using Todo.Services;
using Task = Todo.Models.Task;

namespace Todo.Viewmodel;

public partial class MainViewModel : ObservableObject
{
    readonly TaskService taskService = new();

    public MainViewModel()
    {
        TaskService.OnTasksChanged += RefreshLibrary;
        RefreshLibrary();
    }

    public void RefreshLibrary(List<Task> tasks = null)
    {
        using var db = new TaskContext();
        Tasks = db.Tasks.Where(task => !task.IsCompleted).OrderByDescending(task => task.Importance).ToList();
        CompletedTasks = db.Tasks.Where(task => task.IsCompleted).ToList();
    }

    [ObservableProperty]
    List<Task> tasks;

    [ObservableProperty]
    List<Task> completedTasks;

    [ObservableProperty]
    bool isBusy;

    [RelayCommand]
    public void CompleteTask(Task task) => taskService.Complete(task);

    [RelayCommand]
    public void DeleteTask(Task task) => taskService.Delete(task);

    [RelayCommand]
    public void Clear() => taskService.DeleteCompleted();
}
