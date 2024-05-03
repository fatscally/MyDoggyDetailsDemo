using CommunityToolkit.Maui.Core.Extensions;
using Microsoft.Maui.Controls.Maps;
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
        }
        else
        {
            return Update(model);
        }
    }

    public long Save(DoggyPhotoModel model)
    {
        if (model.Id == 0)
        {
            return Insert(model);
        }
        else
        {
            return Update(model);
        }
    }

    public ObservableCollection<DoggyTableModel> SelectAllDoggies()
    {
        var results = conn.Table<DoggyTableModel>().ToObservableCollection();

        return results;
    }


    public ObservableCollection<DoggyPhotoModel> SelectPhotosByDoggyId(string dogGuid)
    {
        var results = conn.Table<DoggyPhotoModel>().Where(x => x.DogGuid == dogGuid).ToObservableCollection();

        return results;
    }




    /// <summary>
    ///
    /// </summary>
    internal void CreateDatabase()
    {
        CreateTableResult createTableResult;

        createTableResult = conn.CreateTable<ParkTableModel>();
        if (createTableResult == CreateTableResult.Created)
            InsertDoggyParkLocations();


        createTableResult = conn.CreateTable<DoggyPhotoModel>();



        createTableResult = conn.CreateTable<BreedModel>();


        createTableResult = conn.CreateTable<DoggyTableModel>();
        if (createTableResult == CreateTableResult.Created)
            InsertDoggyMetadata();


    }


    internal void InsertDoggyMetadata()
    {
        //base.Insert(model)
        Insert(new DoggyTableModel { DogGuid = "0000", GivenName = "Nala", DateOfBirth = "2022-06-18 00:00:00", Sex = false, ChipNumber = "abc123" });
        Insert(new DoggyTableModel { DogGuid = "0001", GivenName = "Tiko", DateOfBirth = "2021-10-18 00:00:00", Sex = true, ChipNumber = "abc123" });
        Insert(new DoggyTableModel { DogGuid = "0002", GivenName = "Fido", DateOfBirth = "2020-01-01 00:00:00", Sex = true, ChipNumber = "abc123" });
    }


    internal void InsertDoggyParkLocations()
    {
        Insert(new ParkTableModel { Latitude = 53.372929871499075, Longitude = -6.173369488792618, Label = "St. Anne's Park.", Address = "Two parks for big doggies and little doggies.", Type = (int)PinType.Generic });
        Insert(new ParkTableModel { Latitude = 53.30548059641863, Longitude = -6.34339356050867, Label = "Tymon Dog Park.", Address = "One big park for all the doggies.", Type = (int)PinType.Generic });
        Insert(new ParkTableModel { Latitude = 53.342604703264804, Longitude = -6.440872837563679, Label = "Grifeen Valley Park.", Address = "A doggy park inside a human park", Type = (int)PinType.Generic });
    }



}
