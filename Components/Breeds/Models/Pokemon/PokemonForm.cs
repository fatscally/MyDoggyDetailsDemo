using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MyDoggyDetails.Models;

/// <summary>
/// PokemonForm seems to be what they call this type in the API
/// </summary>
public class PokemonForm : INotifyPropertyChanged
{
    private string name;
    [JsonPropertyName("name")]
    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            NotifyPropertyChanged("Name");
        }
    }

    private string url;
    [JsonPropertyName("url")]
    public string Url
    {
        get { return url; }
        set { url = value; }
    }



    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
