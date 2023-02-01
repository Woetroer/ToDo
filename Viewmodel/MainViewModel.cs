using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using System.Collections.ObjectModel;
using Todo;
using Todo.Data;
using Todo.Services;
using Task = Todo.Models.Task;

namespace ToDo.Viewmodel;

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
        Tasks = new ObservableCollection<Task>(db.Tasks.Where(task => task.IsCompleted == false));
    }

    [ObservableProperty]
    ObservableCollection<Task> tasks;

    [ObservableProperty]
    string text;

    [RelayCommand]
    void AddTask()
    {
        //if (!string.IsNullOrWhiteSpace(text) && !taskService.IsDuplicate(new Task { Title = Text }))
        //{
        //    char upper = char.ToUpper(text[0]);
        //    taskService.Add(new Task { Title = upper + text.Substring(1).ToLower() });
        //    text = string.Empty;
        //}

        MopupService.Instance.PushAsync(new PopupPage());
    }

    [RelayCommand]
    public void CompleteTask(Task task) => taskService.Complete(task);

    [RelayCommand]
    public void DeleteTask(Task task) => taskService.Delete(task);
}
