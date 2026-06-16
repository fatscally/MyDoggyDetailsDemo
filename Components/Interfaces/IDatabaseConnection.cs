using SQLite;

namespace MyDoggyDetails.Interfaces;

public interface IDatabaseConnection
{
    SQLiteAsyncConnection GetAsyncConnection();
}
