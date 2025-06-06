using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MyDoggyDetails.API;
using MyDoggyDetails.Repository;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Pages;
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

        // Register services
        builder.Services.AddSingleton<IDatabaseConnection, DatabaseConnection>();
        builder.Services.AddSingleton<IDoggyRepository, DoggyRepository>();
        builder.Services.AddSingleton<IDoggyPhotoRepository, DoggyPhotoRepository>();
        builder.Services.AddSingleton<IBreedsRepository, BreedsRepository>();
        builder.Services.AddSingleton<IParkRepository, ParkRepository>();
        builder.Services.AddSingleton<DataSeeder>();
        builder.Services.AddSingleton<DatabaseInitializer>();
        builder.Services.AddSingleton<IDoggyService, DoggyService>();
        builder.Services.AddSingleton<IParkService, ParkService>();
        builder.Services.AddSingleton<IBreedService, BreedService>();


        // Register view models
        builder.Services.AddSingleton<DoggyListViewModel>();
        builder.Services.AddTransient<DogDetailViewModel>();
        builder.Services.AddSingleton<BreedsListViewModel>();
        builder.Services.AddTransient<BreedDetailViewModel>();
        builder.Services.AddSingleton<ParksViewModel>();

        // Register pages
        builder.Services.AddSingleton<DoggiesPage>();
        builder.Services.AddSingleton<AboutPage>();
        builder.Services.AddTransient<DogDetailsPage>();
        builder.Services.AddTransient<BreedDetailPage>();
        builder.Services.AddSingleton<BreedsListPage>();
        builder.Services.AddSingleton<ParksPage>();
        builder.Services.AddSingleton<RestaurantsPage>();
        builder.Services.AddSingleton<VetsPage>();
        builder.Services.AddSingleton<VendorsPage>();

        builder.Services.AddSingleton<IDogsRestService, DogsRestService>();
        builder.Services.AddSingleton<IDogApiService, DogItemManager>();


#if ANDROID
        builder.Services.AddSingleton<IDoggyPictures, PicturesAndroid>();
#else
        // Add implementations for other platforms
        //builder.Services.AddSingleton<IDoggyPictures, PicturesDefault>();
#endif

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}