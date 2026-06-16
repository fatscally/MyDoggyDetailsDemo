using CommunityToolkit.Maui;
using MyDoggyDetails.API;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Pages;
using MyDoggyDetails.Repository;
using MyDoggyDetails.Services;
using MyDoggyDetails.Utilities.Pictures;
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
        })
            .UseMauiCommunityToolkit()
            .UseMauiMaps();

        // Infrastructure
        builder.Services.AddSingleton<IDatabaseConnection, DatabaseConnection>();
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

        // Repositories
        builder.Services.AddSingleton<IDoggyRepository, DoggyRepository>();
        builder.Services.AddSingleton<IDoggyPhotoRepository, DoggyPhotoRepository>();
        builder.Services.AddSingleton<IBreedsRepository, BreedsRepository>();
        builder.Services.AddSingleton<IParkRepository, ParkRepository>();

        // Initialisation
        builder.Services.AddSingleton<DataSeeder>();
        builder.Services.AddSingleton<DatabaseInitializer>();

        // Services
        builder.Services.AddSingleton<IDoggyService, DoggyService>();
        builder.Services.AddSingleton<IDoggyPhotoService, DoggyPhotoService>();
        builder.Services.AddSingleton<IParkService, ParkService>();
        builder.Services.AddSingleton<IBreedService, BreedService>();

        // ViewModels
        builder.Services.AddSingleton<DoggyListViewModel>();
        builder.Services.AddTransient<DogDetailViewModel>();
        builder.Services.AddSingleton<BreedsListViewModel>();
        builder.Services.AddTransient<BreedDetailViewModel>();
        builder.Services.AddSingleton<ParksViewModel>();

        // Pages
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<DoggiesPage>();
        builder.Services.AddSingleton<AboutPage>();
        builder.Services.AddTransient<DogDetailsPage>();
        builder.Services.AddTransient<BreedDetailPage>();
        builder.Services.AddSingleton<BreedsListPage>();
        builder.Services.AddSingleton<ParksPage>();
        builder.Services.AddSingleton<RestaurantsPage>();
        builder.Services.AddSingleton<VetsPage>();
        builder.Services.AddSingleton<VendorsPage>();

        // HTTP clients
        builder.Services.AddHttpClient<IDogsRestService, DogsRestService>(client =>
        {
            client.BaseAddress = new Uri("https://api.thedogapi.com/v1/");
            client.DefaultRequestHeaders.Add("x-api-key", Base.APIKeys.DogAPIKey);
            client.Timeout = TimeSpan.FromSeconds(30);
        });
        builder.Services.AddHttpClient(); // default client for IDoggyPictures

        AppContext.SetSwitch("System.Globalization.Invariant", true);

#if ANDROID
        builder.Services.AddSingleton<IDoggyPictures, PicturesAndroid>();
#else
        builder.Services.AddSingleton<IDoggyPictures, PicturesIOS>();
#endif

        return builder.Build();
    }
}
