﻿using MyDoggyDetails.Base;
using SQLite;

namespace MyDoggyDetails.Repository;

public class Connection
{

    public static string dbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.DatabaseFileName);




    private SQLiteConnection _localConnection;



    public SQLiteConnection LocalConnection()
    {

        if (_localConnection == null)
            _localConnection = new SQLiteConnection(dbPath);

         
        return _localConnection;


    }
}
