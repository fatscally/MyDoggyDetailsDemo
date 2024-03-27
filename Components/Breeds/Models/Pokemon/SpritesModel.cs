using System.Text.Json.Serialization;

namespace MyDoggyDetails.Models;

public class SpritesModel
{
    //TODO are more images
    public string front_default { get; set; }
    public string back_default { get; set; }
    public string front_shiny { get; set; }
    public string back_shiny { get; set; }
    public OtherImagesModel other { get; set; }

}

public class OtherImagesModel
{
    public imageUrl dream_world  { get; set; }
    
    [JsonPropertyName("official-artwork")]
    public imageUrl officialartwork { get; set; }
}

public class imageUrl
{
    public string front_default { get; set; }
}
