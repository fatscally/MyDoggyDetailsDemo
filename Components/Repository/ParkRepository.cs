using Microsoft.Maui.Controls.Maps;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;

namespace MyDoggyDetails.Repository;

public class ParkRepository : BaseRepository, IParkRepository
{
    public ParkRepository(IDatabaseConnection connection) : base(connection) { }

    public async Task CreateDatabaseAsync()
        => await asyncConn.CreateTableAsync<ParkTableModel>();

    public async Task<IEnumerable<ParkTableModel>> GetAllParksAsync()
        => await asyncConn.Table<ParkTableModel>().ToListAsync();

    public async Task<long> SaveAsync(ParkTableModel model)
        => model.Id == 0 ? await base.InsertAsync(model) : await base.UpdateAsync(model);
}
