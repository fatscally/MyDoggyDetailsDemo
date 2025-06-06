using Microsoft.Maui.Controls.Maps;
using MyDoggyDetails.Interfaces;
using MyDoggyDetails.Models;
using SQLite;

namespace MyDoggyDetails.Repository;

public class ParkRepository : BaseRepository, IParkRepository
{

    public ParkRepository(IDatabaseConnection connection) : base(connection)
    {
  
    }

    public void CreateDatabase()
    {
        var result = conn.CreateTable<ParkTableModel>();
        if (result == CreateTableResult.Created)
            _ = SeedParkDataAsync();
    }

    public long Save(ParkTableModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ParkTableModel>> GetAllParksAsync()
    {
        return conn.Table<ParkTableModel>();
    }



    public async Task CreateDatabaseAsync()
    {

        try
        {

            if (conn == null)
            {
                throw new InvalidOperationException("Database connection is not initialized.");
            }
            conn.CreateTable<ParkTableModel>();
        }
        catch (Exception ex)
        {
            throw;
        }

    }

    public async Task<long> SaveAsync(ParkTableModel model)
    {
        try
        {
            return model.Id == 0 ? await base.InsertAsync(model) : await base.UpdateAsync(model);
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task SeedParkDataAsync()
    {
        try
        {
            await SaveAsync(new ParkTableModel { Latitude = 53.372929871499075, Longitude = -6.173369488792618, Label = "St. Anne's Park.", Address = "Two parks for big doggies and little doggies.", Type = (int)PinType.Generic });
            await SaveAsync(new ParkTableModel { Latitude = 53.30548059641863, Longitude = -6.34339356050867, Label = "Tymon Dog Park.", Address = "One big park for all the doggies.", Type = (int)PinType.Generic });
            await SaveAsync(new ParkTableModel { Latitude = 53.342604703264804, Longitude = -6.440872837563679, Label = "Grifeen Valley Park.", Address = "A doggy park inside a human park", Type = (int)PinType.Generic });

        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
