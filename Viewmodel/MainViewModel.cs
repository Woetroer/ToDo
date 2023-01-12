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

    public void RefreshLibrary(List<Task> books = null) => Tasks = new ObservableCollection<Task>(db.Tasks);

    [ObservableProperty]
    ObservableCollection<Task> tasks;

    [ObservableProperty]
    string text;

    [RelayCommand]
    void AddTask()
    {
        if (!string.IsNullOrWhiteSpace(text)) // if doesnt contain
        {
            taskService.Add(new Task { Title = text });
            text = string.Empty;
        }
    }

    [RelayCommand]
    void DeleteTask(int id) => taskService.Delete(id);
}
