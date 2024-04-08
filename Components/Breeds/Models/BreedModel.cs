using CommunityToolkit.Mvvm.ComponentModel;
using MyDoggyDetails.Utilities.Pictures;
using SQLite;


namespace MyDoggyDetails.Models;

[Table("Breeds")]
public partial class BreedModel : ObservableObject
{
    [ObservableProperty]
    private int id;
    [ObservableProperty]
    private string name;
    [ObservableProperty]
    private string bred_for;
    [ObservableProperty]
    private string breed_group;
    [ObservableProperty]
    private string life_span;
    [ObservableProperty]
    private string temperament;
    [ObservableProperty]
    private string reference_image_id;


    [ObservableProperty]
    private string imperial_weight;
    [ObservableProperty]
    private string metric_weight;

    [ObservableProperty]
    private string imperial_height;
    [ObservableProperty]
    private string metric_height;

    [ObservableProperty]
    private string image_id;
    [ObservableProperty]
    private int image_width;
    [ObservableProperty]
    private int image_height;
    [ObservableProperty]
    private string image_url;
    [ObservableProperty]
    private byte[] localImage;


    [ObservableProperty]
    private byte[] localIcon;

    private Image imgStream = new();

    [Ignore]
    public Image ImgStream
    {
        get => imgStream;
        set => SetProperty(ref imgStream, value);
    }







    //extra classes needed for the webapi
    //remapping the json for database simplicity.
    private BreedImage image;
    [Ignore]
    public BreedImage Image
    {
        get { return image; }
        set { 
            image = value;
            Image_id = image.Id;
            Image_width = image.Width;
            Image_height = image.Height;
            Image_url = image.Url;
        }
    }

    //remappting the json for database simplicity.
    private BreedWeight weight;
    [Ignore]
    public BreedWeight Weight
    {
        get { return weight; }
        set { 
            weight = value;
            Imperial_weight = weight.Imperial;
            Metric_weight = weight.Metric;
        }
    }

    //remappting the json for database simplicity.
    private BreedHeight height;
    [Ignore]
    public BreedHeight Height
    {
        get { return height; }
        set { 
            height = value;
            Imperial_height = height.Imperial;
            Metric_height = height.Metric;
        }
    }



}


//Used by the DogAPI but creates headaches for me using SQLite-Net-PCL
public partial class BreedWeight : ObservableObject
{
    [ObservableProperty]
    private string imperial;
    [ObservableProperty]
    private string metric;
}

//Used by the DogAPI but creates headaches for me using SQLite-Net-PCL
public partial class BreedHeight : ObservableObject
{
    [ObservableProperty]
    private string imperial;
    [ObservableProperty]
    private string metric;
}
//Used by the DogAPI but creates headaches for me using SQLite-Net-PCL
public partial class BreedImage : ObservableObject
{
    [ObservableProperty]
    private string id;
    [ObservableProperty]
    private int width;
    [ObservableProperty]
    private int height;
    [ObservableProperty]
    private string url;
}



