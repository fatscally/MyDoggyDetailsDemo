using SQLite;

namespace MyDoggyDetails.Interfaces;

public interface IDatabaseConnection
{
    SQLiteConnection GetConnection();
}
