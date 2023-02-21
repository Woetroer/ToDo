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

    private async void homeButton_Clicked(object sender, EventArgs e)
    {
        ToTaskView();
    }

    private async void historyButton_Clicked(object sender, EventArgs e)
    {
        ToCompletedView();
    }

    private async void swipedRight_Swiped(object sender, SwipedEventArgs e)
    {
        if (historyView.IsVisible)
            ToTaskView();
    }

    private async void swipedLeft_Swiped(object sender, SwipedEventArgs e)
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
        ((MainViewModel)(this.BindingContext)).TaskViewVisible = true;
        taskView.IsVisible = true;
        historyView.IsVisible = false;
        homeButton.TextColor = Color.FromArgb("#3066BE");
        historyButton.TextColor = Color.FromArgb("#0090DB");
        titleImage.Source = "tasks.png";

        if (animate)
            await Task.WhenAll(titleImage.FadeIn(400, Easing.Linear), taskView.FadeIn(400, Easing.Linear));
    }

    public async void ToCompletedView(bool animate = true)
    {
        ((MainViewModel)(this.BindingContext)).TaskViewVisible = false;
        taskView.IsVisible = false;
        historyView.IsVisible = true;
        historyButton.TextColor = Color.FromArgb("#3066BE");
        homeButton.TextColor = Color.FromArgb("#0090DB");
        titleImage.Source = "completed.png";

        if (animate)
            await Task.WhenAll(titleImage.FadeIn(400, Easing.Linear), historyView.FadeIn(400, Easing.Linear));
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
        await element.FadeTo(1, duration, easing);
        element.IsVisible = true;
    }
}

