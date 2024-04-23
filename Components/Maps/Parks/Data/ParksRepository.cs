using CommunityToolkit.Maui.Core.Extensions;
using MyDoggyDetails.Models;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.Data
{
    class ParksRepository : BaseRepository
    {

        public long Save(ParkTableModel model)
        {

            if (model.Id == 0)
            {
                return Insert(model);
            }
            else
            {
                return Update(model);
            }
        }

        public ObservableCollection<ParkTableModel> SelectAllParks()
        {
            var results = conn.Table<ParkTableModel>().ToObservableCollection();

            return results;
        }


    }
}
