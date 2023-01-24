using Todo.Services;
using ToDo.Viewmodel;
namespace Todo;

public partial class MainPage : ContentPage
{

    private static System.Timers.Timer timer;

    TaskService taskService = new();
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        int total = taskService.TotalTasks();
        if (total == 0)
        {
            animatedArrow.IsVisible = true;
            animatedArrow.IsAnimationEnabled = true;
        }
    }

    private void addTaskButton_Clicked(object sender, EventArgs e)
    {
        addTaskEntry.Text = string.Empty;
        addTaskEntry.IsEnabled = false; // Hide keyboard after adding task
        addTaskEntry.IsEnabled = true;
        animatedArrow.IsVisible = false;
        animatedArrow.IsAnimationEnabled = false;
    }
}

