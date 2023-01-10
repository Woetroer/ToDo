using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ToDo.Viewmodel;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        Tasks = new ObservableCollection<string>();
    }

    [ObservableProperty]
    ObservableCollection<string> tasks;

    [ObservableProperty]
    string text;

    [RelayCommand]
    void AddTask()
    {
        if (text != string.Empty && !tasks.Contains(text))
        {
            Tasks.Add(text);
            text = string.Empty;
        }
    }

    [RelayCommand]
    void DeleteTask(string taskName)
    {
        if (Tasks.Contains(taskName)) Tasks.Remove(taskName);
    }
}
