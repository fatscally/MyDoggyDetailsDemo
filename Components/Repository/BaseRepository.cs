using MyDoggyDetails.Base;
using MyDoggyDetails.Interfaces;
using SQLite;

namespace MyDoggyDetails.Repository;

public abstract class BaseRepository
{
    public string dbPath { get; } = Constants.DatabasePath;

    protected SQLiteConnection conn;

    protected BaseRepository(IDatabaseConnection connection)
    {
        conn = connection?.GetConnection() ?? throw new ArgumentNullException(nameof(connection), "Database connection cannot be null.");
    }

    protected async Task<long> InsertAsync(object model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));
        return conn.Insert(model);
    }

    protected async Task<long> UpdateAsync(object model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));
        return conn.Update(model);
    }

    protected async Task<long> DeleteAsync(object model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));
        return conn.Delete(model);
    }
}