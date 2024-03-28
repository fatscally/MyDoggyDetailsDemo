using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyDoggyDetails.API;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;


internal partial class PokemonViewmodel : BaseViewModel
{
    public int TotalOnlineCount;

    [RelayCommand]
    public void GetFromWeb()
    {
         GetPokemonDetails();
    }

    [ObservableProperty]
    private ObservableCollection<BreedTableModel> breeds;

    public PokemonViewmodel()
    {
        breeds = new BreedsRepository().SelectAllBreeds();
    }

    [ObservableProperty]
    public string getButtonText;

    private void GetPokemonDetails()
    {

        GetButtonText = "Getting Headers";

        GetPokemonHeaders();

        PokemonDetail pokDet;
        ItemManager data = new ItemManager(new RestService());
        Counter = 0;



        foreach (PokemonForm p in PokemonHeaders.Results)
        {
            pokDet = data.GetPokemonDetailAsync(p.Url).Result;
            pokDet.IsDirty = true;

            WebResults.Add(pokDet);

            Counter += 1;
            GetButtonText = "Getting " + Counter.ToString() + " of " + TotalOnlineCount.ToString() + " Pokemon";

            if (counter >= 10)
                break;
        }

        GetButtonText = "Downloaded " + Counter.ToString() + " Pokemon";

    }

    private void GetPokemonHeaders()
    {

        GetButtonText = "Fetching Headers";

        ItemManager http = new ItemManager(new RestService());

        PokemonHeaders = http.GetPokemonHeadersAsync().Result;

        TotalOnlineCount = PokemonHeaders.Count;
    }


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(GetButtonText))]
    private int counter = 0;
    /// <summary>
    /// Used to count in the Pokemon from onllne.
    /// </summary>
    //public int Counter
    //{
    //    get
    //    {
    //        return counter;

    //    }
    //    set
    //    {
    //        counter = value;
    //        NotifyPropertyChanged("Counter");
    //        NotifyPropertyChanged("GetButtonText");
    //    }
    //}

    [ObservableProperty]
    private PokemonForm selectedPokemonForm;

    [ObservableProperty]
    private PokemonHeader pokemonHeaders;

    [ObservableProperty]
    private ObservableCollection<PokemonDetail> webResults = new ObservableCollection<PokemonDetail>();



}
