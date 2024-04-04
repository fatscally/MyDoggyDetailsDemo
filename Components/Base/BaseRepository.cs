using MyDoggyDetails.Base;
using SQLite;


namespace MyDoggyDetails.Data;

internal class BaseRepository
{
    public string dbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.DatabaseFileName);

    internal SQLiteConnection conn;


    internal BaseRepository()
    {
        conn = new SQLiteConnection(dbPath);
    }




    internal long Insert( object model)
    {
        return conn.Insert(model);
    }

    internal long Update(object model)
    {
        return conn.Update(model);
    }

    internal long Delete(object model)
    {
        return conn.Delete(model);
    }

}
