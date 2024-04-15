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
            SaveBreed(model);
        }            
     }



    internal async Task SaveBreed(BreedModel model)
    {
        BreedModel bm = (from b in conn.Table<BreedModel>()
                         where b.Id == model.Id
                         select b).FirstOrDefault();
        if (bm != null)

            _ = Update(model);
        else
            _ = Insert(model);
    }



    internal ObservableCollection<BreedModel> SelectAllBreeds()
    {
        var results = conn.Table<BreedModel>().ToObservableCollection();

        return results;
    }


    internal async Task<BreedModel> SelectBreedById(int id)
    {
        BreedModel results = conn.Table<BreedModel>().FirstOrDefault(b => b.Id == id);

        return results;
    }

}
