using Todo.Viewmodel;

namespace Todo;

public partial class History : ContentPage
{
	public History(HistoryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}