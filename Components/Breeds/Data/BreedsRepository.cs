using CommunityToolkit.Maui.Core.Extensions;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.Data;

internal class BreedsRepository : BaseRepository
{
    internal async Task InsertList(List<BreedModel> breedModels)
    {
        foreach (var model in breedModels)
        {
            _ = Insert(model);
        }
    }

    internal ObservableCollection<BreedModel> SelectAllBreeds()
    {
        var results = conn.Table<BreedModel>().ToObservableCollection();

        return results;
    }

}
