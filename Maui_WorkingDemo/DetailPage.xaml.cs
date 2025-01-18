using Maui_WorkingDemo.ViewModel;

namespace Maui_WorkingDemo;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)

    {
		InitializeComponent();
		BindingContext = vm;
	}
}