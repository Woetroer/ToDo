using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Todo.Services;
using Task = Todo.Models.Task;

namespace Todo.Viewmodel
{
    partial class AddTaskPopUpViewModel : ObservableObject
    {
        private readonly TaskService taskService = new();

        [ObservableProperty]
        string taskTitle;

        [ObservableProperty]
        string taskDescription;

        [RelayCommand]
        void AddTask()
        {
            if (taskTitle != null & taskDescription != null)
            {
                taskService.Add(new Task
                { Title = taskTitle/*, Description = taskDescription */});
            }
        }
    }
}
