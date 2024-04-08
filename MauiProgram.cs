using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MyDoggyDetails.Pages;
using MyDoggyDetails.ViewModels;

namespace MyDoggyDetails;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();

        builder.Services.AddSingleton<DoggiesPage>();
        builder.Services.AddSingleton<DoggiesViewmodel>();


        builder.Services.AddTransient<DogDetailsPage>();

        builder.Services.AddTransient<BreedDetailPage>();


#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}