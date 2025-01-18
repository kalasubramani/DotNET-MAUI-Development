using Maui_WorkingDemo.ViewModel;
using Microsoft.Extensions.Logging;

namespace Maui_WorkingDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //register connectivity service to main pgm
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

            //creates a copy and keeps it in memory thru app life cycle
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            //creates a copy every single time we need and destroyed when it is done
            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<DetailViewModel>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
