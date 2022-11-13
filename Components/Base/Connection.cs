using SQLite;
using System.Data;

namespace MyDoggyDetails.Data;

public class Connection
{

    string pathToDatabase;
    string databaseName = "doggy.db3";
    string db;


    private SQLiteConnection _localConnection;


    public Connection()
    {
        pathToDatabase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        databaseName = "doggy.db3";

        db = Path.Combine(pathToDatabase, databaseName);
    }

    public SQLiteConnection LocalConnection()
    {

        if (_localConnection == null)
            _localConnection = new SQLiteConnection("Data Source = " + db);

        try
        {
            //if (_localConnection.State != ConnectionState.Open)
            //{
            //    _localConnection = new SQLiteConnection("Data Source = " + db);
            //    _localConnection.Open();
            //}

            return _localConnection;

        }
        catch (Exception)
        {
            throw;
        }
        finally
        {

        }

    }
}
