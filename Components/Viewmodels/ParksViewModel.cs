using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using MyDoggyDetails.Models;
using MyDoggyDetails.Services;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;

public partial class ParksViewModel : BaseViewModel
{

    private readonly IParkService _parkService;


    public ParksViewModel(IParkService parkService)
    {
        _parkService = parkService;
        Map.IsShowingUser = true;
        
        _ = InitializeAsync();

    }

    [ObservableProperty] private Microsoft.Maui.Controls.Maps.Map map = new();
    [ObservableProperty] ObservableCollection<ParkTableModel> parks = new();
    [ObservableProperty] private List<Pin> pins = [];

    partial void OnParksChanged(ObservableCollection<ParkTableModel> value)
    {
        Pins.Clear();
        foreach (var park in value)
        {
            var pin = new Pin
            {
                Label = park.Label,
                Address = park.Address,
                Type = (PinType)park.Type,
                Location = new Location(park.Latitude, park.Longitude)
            };
            Pins.Add(pin);
            Map.Pins.Add(pin);
        }
    }






    public async Task InitializeAsync()
    {
       
        _ = LoadParksAsync();

    }

    private async Task LoadParksAsync()
    {
        try
        {
            Console.WriteLine("ParksViewModel: Loading parks...");
            var parksList = await _parkService.GetAllParksAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Parks.Clear();
                Map.Pins.Clear();
                foreach (var park in parksList)
                {
                    if (park != null)
                    {
                        Parks.Add(park);
                        var pin = new Pin
                        {
                            Label = park.Label,
                            Address = park.Address,
                            Type = (PinType)park.Type,
                            Location = new Location(park.Latitude, park.Longitude)
                        };
                        Map.Pins.Add(pin);
                    }
                    else
                    {
                        Console.WriteLine("ParksViewModel: Null park in list.");
                    }
                }
                if (Parks.Any())
                {
                    
                    Map.MoveToRegion(MapSpan.FromCenterAndRadius(
                        new Location(Parks.First().Latitude, Parks.First().Longitude),
                        Distance.FromKilometers(5)));
                }
            });
            Console.WriteLine("ParksViewModel: Parks loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ParksViewModel: Error loading parks: {ex}");
            throw;
        }
    }

}
