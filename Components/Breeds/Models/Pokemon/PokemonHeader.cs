using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace MyDoggyDetails.Models;

public class PokemonHeader : INotifyPropertyChanged
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("next")]
    public string Next { get; set; }

    [JsonPropertyName("previous")]
    public string Previous { get; set; }

    [JsonPropertyName("results")]
    private ObservableCollection<PokemonForm> results;

    public ObservableCollection<PokemonForm> Results
    {
        get { return results; }
        set { results = value;
            NotifyPropertyChanged("Results");
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }

    protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
    {
        if (!Equals(field, newValue))
        {
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        return false;
    }

    private System.Collections.IEnumerable pokemonHeaders;

    public System.Collections.IEnumerable PokemonHeaders { get => pokemonHeaders; set => SetProperty(ref pokemonHeaders, value); }

}
