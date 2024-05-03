using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace MyDoggyDetails.Models;

public partial class DoggyPhotoModel : BaseTableModel
{

    [ObservableProperty]
    private string dogGuid;

    [ObservableProperty]
    private string fileName;


    //private string filePath;
    //[Ignore]
    //public string FilePath
    //{
    //    get { return filePath; }
    //    set => SetProperty<string>(ref filePath, value, nameof(FilePath));
    //}

}
