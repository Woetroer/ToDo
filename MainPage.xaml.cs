using ToDo.Viewmodel;
namespace Todo;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private void addTaskButton_Clicked(object sender, EventArgs e)
	{
		addTaskEntry.Text = string.Empty;
		addTaskEntry.IsEnabled = false; // Hide keyboard after adding task
		addTaskEntry.IsEnabled = true;
	}
}

