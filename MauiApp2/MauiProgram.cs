using Microsoft.Extensions.Logging;
using Refit;

namespace MauiApp2
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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddTransient<IExternalAPI, MyApiService>();
            builder.Services.AddRefitClient<IExternalAPI>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new System.Uri("https://dummyjson.com");
            });

            builder.Services.AddTransient<HttpClient>(provider =>
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://dummyjson.com");
                return httpClient;
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
