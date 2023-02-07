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
        homeButton.TextColor = Color.FromArgb("#3066BE");
        historyButton.TextColor = Color.FromArgb("#0090DB");
        historyButton.FontAttributes = FontAttributes.None;
        taskView.IsVisible = true;
        historyView.IsVisible = false;
        viewTitle.Text = "Tasks";
    }

    private void historyButton_Clicked(object sender, EventArgs e)
    {
        historyButton.TextColor = Color.FromArgb("#3066BE");
        homeButton.TextColor = Color.FromArgb("#0090DB");
        historyView.IsVisible = true;
        taskView.IsVisible = false;
        viewTitle.Text = "Completed";
    }

    private void swipedRight_Swiped(object sender, SwipedEventArgs e)
    {
        if (historyView.IsVisible)
        {
            historyView.IsVisible = false;
            taskView.IsVisible = true;
            homeButton.TextColor = Color.FromArgb("#3066BE");
            historyButton.TextColor = Color.FromArgb("#0090DB");
            viewTitle.Text = "Tasks";
        }
    }

    private void swipedLeft_Swiped(object sender, SwipedEventArgs e)
    {
        if (taskView.IsVisible)
        {
            taskView.IsVisible = false;
            historyView.IsVisible = true;
            historyButton.TextColor = Color.FromArgb("#3066BE");
            homeButton.TextColor = Color.FromArgb("#0090DB");
            viewTitle.Text = "Completed";
        }
    }
}

