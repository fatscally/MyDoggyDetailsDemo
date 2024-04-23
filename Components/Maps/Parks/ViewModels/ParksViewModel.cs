using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;

public partial class ParksViewModel : BaseViewModel
{


    [ObservableProperty]
    private Microsoft.Maui.Controls.Maps.Map map;

    [ObservableProperty]
    ObservableCollection<ParkTableModel> parks;

    partial void OnParksChanged(ObservableCollection<ParkTableModel> value)
    {
        Pin pin;
        //convert the table rows to Pins
        foreach (var park in Parks)
        {
            pin = new();
            pin.Label = park.Label;
            pin.Address = park.Address;
            pin.Type = (PinType)park.Type;
            pin.Location = new Location(park.Latitude, park.Longitude);

            Map.Pins.Add(pin);
        }
    }

    [ObservableProperty]
    private List<Pin> pins = [];


    public ParksViewModel()
    {

        Location location;

        Task<Location> getDeviceLocation = GetCachedLocation();
        location = getDeviceLocation.Result;

        MapSpan mapSpan = new MapSpan(location, 0.1, 0.1);

        Map = new(mapSpan);

        Map.IsShowingUser = true;

        Parks = LoadUpParks();

    }


    private ObservableCollection<ParkTableModel> LoadUpParks()
    {
        return new ParksRepository().SelectAllParks();
    }


    [RelayCommand]
    public async Task NavigateToBuilding25()
    {
        var location = new Location(47.645160, -122.1306032);
        var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

        try
        {
            await Microsoft.Maui.ApplicationModel.Map.Default.OpenAsync(location, options);
        }
        catch (Exception ex)
        {
            // No map application available to open
        }
    }

    public async Task<Location> GetCachedLocation()
    {
        try
        {
            Location location = await Geolocation.Default.GetLastKnownLocationAsync();

            if (location != null)
                return location; // $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
            else
                return new Location(53.347442617966834, -6.259081737757894);  //O'Connell Bridge Dublin

        }
        catch (FeatureNotSupportedException fnsEx)
        {
            // Handle not supported on device exception
        }
        catch (FeatureNotEnabledException fneEx)
        {
            // Handle not enabled on device exception
        }
        catch (PermissionException pEx)
        {
            // Handle permission exception
        }
        catch (Exception ex)
        {
            // Unable to get location
        }

        return new Location();
    }

}
