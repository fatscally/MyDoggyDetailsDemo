using MyDoggyDetails.Base;
using SQLite;

namespace MyDoggyDetails.Data;

public class Connection
{

    public static string dbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.DatabaseFileName);

    public static string photosPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "breedImages");


    private SQLiteConnection _localConnection;



    public SQLiteConnection LocalConnection()
    {

        if (_localConnection == null)
            _localConnection = new SQLiteConnection(dbPath);

         
        return _localConnection;


    }
}
