using Todo.Services;
using Todo.Viewmodel;
namespace Todo;

public partial class MainPage : ContentPage
{

    TaskService taskService = new();
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void homeButton_Clicked(object sender, EventArgs e)
    {
        ((MainViewModel)(this.BindingContext)).TaskViewVisible = true;
        taskView.IsVisible = true;
        historyView.IsVisible = false;

        homeButton.TextColor = Color.FromArgb("#3066BE");
        historyButton.TextColor = Color.FromArgb("#0090DB");
        historyButton.FontAttributes = FontAttributes.None;
        titleImage.Source = "tasks.png";
    }

    private void historyButton_Clicked(object sender, EventArgs e)
    {
        ((MainViewModel)(this.BindingContext)).TaskViewVisible = false;
        taskView.IsVisible = false;
        historyView.IsVisible = true;

        historyButton.TextColor = Color.FromArgb("#3066BE");
        homeButton.TextColor = Color.FromArgb("#0090DB");
        titleImage.Source = "completed.png";
        addTaskButton.FadeTo(200);
    }

    private void swipedRight_Swiped(object sender, SwipedEventArgs e)
    {
        if (historyView.IsVisible)
        {
            ((MainViewModel)(this.BindingContext)).TaskViewVisible = true;
            taskView.IsVisible = true;
            historyView.IsVisible = false;

            homeButton.TextColor = Color.FromArgb("#3066BE");
            historyButton.TextColor = Color.FromArgb("#0090DB");
            titleImage.Source = "tasks.png";
        }
    }

    private void swipedLeft_Swiped(object sender, SwipedEventArgs e)
    {
        if (taskView.IsVisible)
        {
            ((MainViewModel)(this.BindingContext)).TaskViewVisible = false;
            taskView.IsVisible = false;
            historyView.IsVisible = true;

            historyButton.TextColor = Color.FromArgb("#3066BE");
            homeButton.TextColor = Color.FromArgb("#0090DB");
            titleImage.Source = "completed.png";

            //titleImage.IsVisible = false;
            //await titleImage.FadeIn(100, Easing.SinIn);
        }
    }
}

public static class VisualElementExtensions
{
    public static async System.Threading.Tasks.Task FadeOut(this VisualElement element, uint duration = 400, Easing easing = null)
    {
        await element.FadeTo(0, duration, easing);
        element.IsVisible = false;
    }

    public static async System.Threading.Tasks.Task FadeIn(this VisualElement element, uint duration = 400, Easing easing = null)
    {
        await element.FadeTo(1, duration, easing);
        element.IsVisible = true;
    }
}

