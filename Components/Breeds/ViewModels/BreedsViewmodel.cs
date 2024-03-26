using CommunityToolkit.Mvvm.ComponentModel;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;

[ObservableObject]
internal partial class BreedsViewmodel
{

    [ObservableProperty]
    private ObservableCollection<BreedTableModel> breeds;

    public BreedsViewmodel()
    {
        breeds = new BreedsRepository().SelectAllBreeds();
    }

    

}
