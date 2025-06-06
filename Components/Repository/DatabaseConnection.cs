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

    public SQLiteConnection GetConnection()
    {
        try
        {
            var connection = new SQLiteConnection(_dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
            if (connection == null)
                throw new InvalidOperationException("Failed to create SQLite connection.");
            return connection;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating SQLite connection: {ex.Message}");
            throw;
        }
    }
}