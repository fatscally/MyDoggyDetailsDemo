using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;
using System.Threading.Tasks;

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


    public async Task CreateDatabase()
    {
        await asyncConn.CreateTableAsync<DoggyPhotoModel>();
    }

    public async Task<IEnumerable<DoggyPhotoModel>> SelectPhotosByDoggyId(string dogGuid)
    {
        return await asyncConn.Table<DoggyPhotoModel>().Where(x => x.DogGuid == dogGuid).ToListAsync();
    }


}
