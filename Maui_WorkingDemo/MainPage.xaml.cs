using Maui_WorkingDemo.ViewModel;

namespace Maui_WorkingDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }

}
