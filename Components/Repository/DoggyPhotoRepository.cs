using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.Repository;

public class DoggyPhotoRepository : BaseRepository, IDoggyPhotoRepository
{
    public DoggyPhotoRepository(IDatabaseConnection connection) : base(connection)
    {
    }

    public async Task<long> SaveAsync(DoggyPhotoModel model)
    {
        return model.Id == 0 ? await InsertAsync(model) : await UpdateAsync(model);
    }

    public IEnumerable<DoggyPhotoModel> SelectPhotosByDoggyId(string dogGuid)
    {
        return conn.Table<DoggyPhotoModel>().Where(x => x.DogGuid == dogGuid);
    }

    public void CreateDatabase()
    {
        conn.CreateTable<DoggyPhotoModel>();
    }
}
