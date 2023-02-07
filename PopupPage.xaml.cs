using Mopups.Services;

namespace Todo;

public partial class PopupPage
{
    public PopupPage()
    {
        InitializeComponent();
    }

    private void addTaskButton_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(taskTitleEntry.Text) && !string.IsNullOrEmpty(descriptionEntry.Text))
            MopupService.Instance.RemovePageAsync(this);
    }
}