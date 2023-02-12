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
        historyView.IsVisible = false;

        homeButton.TextColor = Color.FromArgb("#3066BE");
        historyButton.TextColor = Color.FromArgb("#0090DB");
        historyButton.FontAttributes = FontAttributes.None;
        titleImage.Source = "tasks.png";
    }

    private void historyButton_Clicked(object sender, EventArgs e)
    {
        ((MainViewModel)(this.BindingContext)).TaskViewVisible = false;
        historyView.IsVisible = true;

        historyButton.TextColor = Color.FromArgb("#3066BE");
        homeButton.TextColor = Color.FromArgb("#0090DB");
        titleImage.Source = "completed.png";
    }

    private void swipedRight_Swiped(object sender, SwipedEventArgs e)
    {
        if (historyView.IsVisible)
        {
            ((MainViewModel)(this.BindingContext)).TaskViewVisible = true;
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
            historyView.IsVisible = true;

            historyButton.TextColor = Color.FromArgb("#3066BE");
            homeButton.TextColor = Color.FromArgb("#0090DB");
            titleImage.Source = "completed.png";
        }
    }
}

