using CommunityToolkit.Maui.Core.Extensions;
using MyDoggyDetails.Models;
using SQLite;
using System.Collections.ObjectModel;


//There are 2 data access classes to demonstrate the two different styles
namespace MyDoggyDetails.Data;

internal class DoggyRepository : BaseRepository
{


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
       
   
        createTableResult = conn.CreateTable<BreedModel>();


        createTableResult = conn.CreateTable<DoggyTableModel>();
        if (createTableResult == CreateTableResult.Created)
            InsertDoggyMetadata();


    }


    internal void InsertDoggyMetadata()
    {
        //base.Insert(model)
        Insert(new DoggyTableModel { GivenName = "Nala", DateOfBirth = "2022-06-18 00:00:00", Sex = 1, ChipNumber = "abc123" });
        Insert(new DoggyTableModel { GivenName = "Tiko", DateOfBirth = "2021-10-18 00:00:00", Sex = 0, ChipNumber = "abc123" });
        Insert(new DoggyTableModel { GivenName = "Fido", DateOfBirth = "2020-01-01 00:00:00", Sex = 0, ChipNumber = "abc123" });
    }



}
