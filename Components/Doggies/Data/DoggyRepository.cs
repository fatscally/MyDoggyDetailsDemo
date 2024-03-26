using CommunityToolkit.Maui.Core.Extensions;
using MyDoggyDetails.Models;
using SQLite;
using System.Collections.ObjectModel;


//There are 2 data access classes to demonstrate the two different styles
namespace MyDoggyDetails.Data;

internal class DoggyRepository : BaseRepository
{
    //private readonly SQLiteConnection conn;


    //public string dbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.DatabaseFileName);
    //static DoggyRepository()
    //{
    //    //conn = new SQLiteConnection(dbPath);
    //    //baseRepository = new(conn);
    //}

    public long Save(DoggyTableModel model)
    {
        if (model.Id == 0)
        {
            return Insert(model);
        } else
        {
            return Update(model);
        }
    }

    public ObservableCollection<DoggyTableModel> SelectAllDoggies()
    {
        var results = conn.Table<DoggyTableModel>().ToObservableCollection();

        return results;
    }



    /// <summary>
    ///
    /// </summary>
    internal void CreateDatabase()
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

    private void UpdateBreedsMetadata()
    {
        Update(new BreedTableModel { Name = "Mini Schnauzer", Size = "Small" });
        Update(new BreedTableModel { Name = "Cocker Spaniel", Size = "Small" });
    }

    private void InsertBreedsMetadata()
    {
        Insert(new BreedTableModel { Name = "Mini Schnauzer", Size = "Small" });
        Insert(new BreedTableModel { Name = "Cocker Spaniel", Size = "Small" });
    }

    internal void InsertDoggyMetadata()
    {
        Insert(new DoggyTableModel { GivenName = "Nala", DateOfBirth = "2022-06-18 00:00:00", Sex = 1, ChipNumber = "abc123" });
        Insert(new DoggyTableModel { GivenName = "Tiko", DateOfBirth = "2021-10-18 00:00:00", Sex = 0, ChipNumber = "abc123" });
        Insert(new DoggyTableModel { GivenName = "Fido", DateOfBirth = "2020-01-01 00:00:00", Sex = 0, ChipNumber = "abc123" });
    }
    internal void UpdateDoggyMetadata()
    {
        Update(new DoggyTableModel { Id = 1, GivenName = "Nala", DateOfBirth = "2022-06-18 00:00:00", Sex = 1, ChipNumber = "abc123" });
        Update(new DoggyTableModel { Id = 2, GivenName = "Tiko", DateOfBirth = "2021-10-18 00:00:00", Sex = 0, ChipNumber = "abc123" });
        Update(new DoggyTableModel { Id = 3, GivenName = "Fido", DateOfBirth = "2020-01-01 00:00:00", Sex = 0, ChipNumber = "abc123" });
    }


}
