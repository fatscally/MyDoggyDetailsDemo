using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.API;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;


internal partial class BreedsViewmodel : BaseViewModel
{
    public int TotalOnlineCount;

    public BreedsViewmodel()
    {
         Breeds = new BreedsRepository().SelectAllBreeds();
    }

    [RelayCommand]
    public void GetBreedsFromWeb()
    {
        GetButtonText = "clicked...";
        GetBreeds();
    }

    [RelayCommand]
    public void SaveBreedsToDb()
    {
        SaveAsync();
    }

    async void SaveAsync()
    {
        await new BreedsRepository().InsertList(Breeds.ToList());
    }

    [ObservableProperty]
    private ObservableCollection<BreedModel> breeds;



    [ObservableProperty]
    public string getButtonText;



    private void GetBreeds()
    {

        GetButtonText = "Fetching Breeds";

        DogItemManager http = new(new DogsRestService());

        Breeds = http.GetAllBreeds().Result.ToObservableCollection<BreedModel>();

        GetButtonText = "Found " + Breeds.Count + " breeds";

    }


   

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(GetButtonText))]
    private int counter = 0;



    [ObservableProperty]
    private ObservableCollection<BreedModel> webResults = new();



}
