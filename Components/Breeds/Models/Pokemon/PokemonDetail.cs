using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MyDoggyDetails.Models;

[Table("Pokemon")]
public partial class PokemonDetail : BaseTableModel
{ 

    //private int id;
    //[PrimaryKey, AutoIncrement]
    //public int Id
    //{
    //    get { return id; }
    //    set
    //    {
    //        id = value;
    //        NotifyPropertyChanged("Id");
    //    }
    //}

    [ObservableProperty]
    [property: JsonPropertyName("name")]
    [property:Column("PokemonName")]    
    private string name;


    [ObservableProperty]
    private string details;


    [ObservableProperty]
    private string type;


    [ObservableProperty]
    [property: JsonPropertyName("sprites")]    
    private SpritesModel sprites;
    



    [ObservableProperty]
    private byte[] logo;



    [ObservableProperty]
    [property: JsonPropertyName("height")]    
    private double height;


    [ObservableProperty]
    [property:JsonPropertyName("weight")]
    private double weight;


    [ObservableProperty]
    private bool isFavourite;


    [Ignore]
    public bool IsDirty { get; set; }



}
