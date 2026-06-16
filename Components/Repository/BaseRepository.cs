using MyDoggyDetails.Interfaces;
using SQLite;

namespace MyDoggyDetails.Repository;

public abstract class BaseRepository
{
    protected SQLiteAsyncConnection asyncConn;

    protected BaseRepository(IDatabaseConnection connection)
    {
        asyncConn = connection?.GetAsyncConnection() ?? throw new ArgumentNullException(nameof(connection), "Database async connection cannot be null.");
    }

    protected async Task<long> InsertAsync(object model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));
        return await asyncConn.InsertAsync(model);
    }

    protected async Task<long> UpdateAsync(object model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));
        return await asyncConn.UpdateAsync(model);
    }

    protected async Task<long> DeleteAsync(object model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));
        return await asyncConn.DeleteAsync(model);
    }
}