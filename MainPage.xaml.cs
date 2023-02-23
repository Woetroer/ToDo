using Mopups.Services;
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
        ToTaskView();
    }

    private void completedButton_Clicked(object sender, EventArgs e)
    {
        ToCompletedView();
    }

    private void swipedRight_Swiped(object sender, SwipedEventArgs e)
    {
        if (completedView.IsVisible)
            ToTaskView();
    }

    private void swipedLeft_Swiped(object sender, SwipedEventArgs e)
    {
        if (taskView.IsVisible)
            ToCompletedView();
    }

    private void addTaskButton_Clicked(object sender, EventArgs e)
    {
        ToTaskView();
        MopupService.Instance.PushAsync(new PopupPage());
    }

    public async void ToTaskView(bool animate = true)
    {
        taskView.IsVisible = true;
        completedView.IsVisible = false;
        completedButton.TextColor = Color.FromArgb("#696969");
        homeButton.TextColor = Color.FromArgb("#0090DB");
        titleImage.Source = "tasks.png";

        if (animate)
            await Task.WhenAll(titleImage.FadeIn(400, Easing.Linear), taskView.FadeIn(400, Easing.Linear), clearButton.FadeOut(0, Easing.Linear));
    }

    public async void ToCompletedView(bool animate = true)
    {
        taskView.IsVisible = false;
        completedView.IsVisible = true;
        homeButton.TextColor = Color.FromArgb("#696969");
        completedButton.TextColor = Color.FromArgb("#0090DB");
        titleImage.Source = "completed.png";


        if (animate)
            await Task.WhenAll(titleImage.FadeIn(400, Easing.Linear), completedView.FadeIn(400, Easing.Linear), clearButton.FadeIn(400, Easing.Linear));
    }
}

public static class VisualElementExtensions
{
    public static async System.Threading.Tasks.Task FadeOut(this VisualElement element, uint duration = 400, Easing easing = null)
    {
        element.Opacity = 1;
        await element.FadeTo(0, duration, easing);
        element.IsVisible = false;
    }

    public static async System.Threading.Tasks.Task FadeIn(this VisualElement element, uint duration = 400, Easing easing = null)
    {
        element.Opacity = 0;
        element.IsVisible = true;
        await element.FadeTo(1, duration, easing);

    }
}

