using CommunityToolkit.Maui.Core.Extensions;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.Data;

internal class BreedsRepository : BaseRepository
{
    internal ObservableCollection<BreedTableModel> SelectAllBreeds()
    {
        var results = conn.Table<BreedTableModel>().ToObservableCollection();

        return results;
    }

}
