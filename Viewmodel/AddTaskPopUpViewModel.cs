using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Todo.Services;
using Task = Todo.Models.Task;

namespace Todo.Viewmodel;

partial class AddTaskPopUpViewModel : ObservableObject
{
    private readonly TaskService taskService = new();

    [ObservableProperty]
    string taskTitle;

    [ObservableProperty]
    string taskDescription;

    [ObservableProperty]
    int taskImportance;

    [RelayCommand]
    void AddTask()
    {
        if (TaskTitle != null && !taskService.IsDuplicate(TaskTitle) && TaskImportance > 0)
        {
            taskService.Add(new Task
            { Title = TaskTitle, Importance = TaskImportance });
        }
    }
}
