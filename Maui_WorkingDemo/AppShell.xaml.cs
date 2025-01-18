namespace Maui_WorkingDemo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //ridrects to newpage1
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        }
    }
}
