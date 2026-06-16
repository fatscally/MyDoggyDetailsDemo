using MyDoggyDetails.Base;
using MyDoggyDetails.Interfaces;
using SQLite;

namespace MyDoggyDetails.Repository;

public class DatabaseConnection : IDatabaseConnection
{
    private readonly string _dbPath;

    public DatabaseConnection()
    {
        _dbPath = Constants.DatabasePath;
        Directory.CreateDirectory(Path.GetDirectoryName(_dbPath)); // Ensure directory exists
    }

    public SQLiteAsyncConnection GetAsyncConnection()
    {

        return new SQLiteAsyncConnection(_dbPath);

    }

}