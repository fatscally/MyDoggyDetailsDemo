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

    [RelayCommand]
    public void GetFromWeb()
    {
        GetButtonText = "clicked...";
        GetBreeds();
    }

    [ObservableProperty]
    private ObservableCollection<BreedModel> breeds;

    //[ObservableProperty]
    //private BreedModel[] breed;

    public BreedsViewmodel()
    {
        //breeds = new BreedsRepository().SelectAllBreeds();
    }

    [ObservableProperty]
    public string getButtonText;



    private void GetBreeds()
    {

        GetButtonText = "Fetching Breeds";

        DogItemManager http = new DogItemManager(new DogsRestService());

        Breeds = http.GetAllBreeds().Result.ToObservableCollection<BreedModel>();

        GetButtonText = "Found " + Breeds.Count() + " breeds";

    }


   

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(GetButtonText))]
    private int counter = 0;


    [ObservableProperty]
    private PokemonForm selectedPokemonForm;

    [ObservableProperty]
    private PokemonHeader pokemonHeaders;

    [ObservableProperty]
    private ObservableCollection<BreedModel> webResults = new();



}
