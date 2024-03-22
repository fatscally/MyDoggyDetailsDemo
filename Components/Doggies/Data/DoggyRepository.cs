using CommunityToolkit.Maui.Core.Extensions;
using MyDoggyDetails.Components.Base;
using MyDoggyDetails.Models;
using SQLite;
using System.Collections.ObjectModel;

//There are 2 data access classes to demonstrate the two different styles
namespace MyDoggyDetails.Data;

public static class DoggyRepository 
{
    private static readonly SQLiteConnection conn;
    public static string dbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.DatabaseFileName);
    static DoggyRepository()
    {
        conn = new SQLiteConnection(dbPath);
    }

    public static long Save(DoggyTableModel model)
    {
        if (model.Id == 0)
        {
            return Insert(model);
        } else
        {
            return Update(model);
        }
    }

    public static ObservableCollection<DoggyTableModel> SelectAllDoggies()
    {
        var results = conn.Table<DoggyTableModel>().ToObservableCollection();

        return results;
    }

    private static long Insert(object model)
    {
            return conn.Insert(model);
    }

    private static long Update(object model)
    {
        return conn.Update(model);
    }   

    public static long Delete(object model)
    {
        return conn.Delete(model);
    }


    /// <summary>
    ///
    /// </summary>
    internal static void CreateDatabase()
    {
        CreateTableResult createTableResult;
        
        createTableResult = conn.CreateTable<BreedTableModel>();

        if (createTableResult == CreateTableResult.Created)
            InsertBreedsMetadata();
        //else if (createTableResult == CreateTableResult.Migrated)
           //UpdateBreedsMetadata();


        createTableResult = conn.CreateTable<DoggyTableModel>();
        if (createTableResult == CreateTableResult.Created)
            InsertDoggyMetadata();
        //else if (createTableResult == CreateTableResult.Migrated)
            //UpdateDoggyMetadata();

    }

    private static void UpdateBreedsMetadata()
    {
        Update(new BreedTableModel { Name = "Mini Schnauzer", Size = "Small" });
        Update(new BreedTableModel { Name = "Cocker Spaniel", Size = "Small" });
    }

    private static void InsertBreedsMetadata()
    {
        Insert(new BreedTableModel { Name = "Mini Schnauzer", Size = "Small" });
        Insert(new BreedTableModel { Name = "Cocker Spaniel", Size = "Small" });
    }

    internal static void InsertDoggyMetadata()
    {
        Insert(new DoggyTableModel { GivenName = "Nala", DateOfBirth = "2022-06-18 00:00:00", Sex = 0, ChipNumber = "abc123" });
        Insert(new DoggyTableModel { GivenName = "Tiko", DateOfBirth = "2021-10-18 00:00:00", Sex = 0, ChipNumber = "abc123" });
        Insert(new DoggyTableModel { GivenName = "Fido", DateOfBirth = "2020-01-01 00:00:00", Sex = 0, ChipNumber = "abc123" });
    }
    internal static void UpdateDoggyMetadata()
    {
        Update(new DoggyTableModel { GivenName = "Nala", DateOfBirth = "2022-06-18 00:00:00", Sex = 0, ChipNumber = "abc123" });
        Update(new DoggyTableModel { GivenName = "Tiko", DateOfBirth = "2021-10-18 00:00:00", Sex = 0, ChipNumber = "abc123" });
        Update(new DoggyTableModel { GivenName = "Fido", DateOfBirth = "2020-01-01 00:00:00", Sex = 0, ChipNumber = "abc123" });
    }
}
