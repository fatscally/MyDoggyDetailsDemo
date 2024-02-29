
using CommunityToolkit.Mvvm.ComponentModel;
using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using MyDoggyDetails.Utilities;
using System.Collections.ObjectModel;

namespace MyDoggyDetails.ViewModels;

public partial class DoggiesViewmodel : BaseViewModel
{

    public DoggiesViewmodel()
    {
        //MoveDbToProperPlace();

        DoggyRepository repository= new DoggyRepository();

         Doggies = repository.SelectAll();
    }

    //private void MoveDbToProperPlace()
    //{
    //    var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
    //    using (Stream stream = assembly.GetManifestResourceStream("MyDoggyDetails.Database.doggy.db3"))
    //    {
    //        using (MemoryStream memoryStream = new MemoryStream())
    //        {
    //            stream.CopyTo(memoryStream);
    //            File.WriteAllBytes(DoggyRepository.dbPath, memoryStream.ToArray());
    //        }
    //    }
    //}


    private ObservableCollection<DoggyTableModel> doggies;

    public ObservableCollection<DoggyTableModel> Doggies
    {
        get { return doggies; }
        set
        {
            if (value is null) return;

            doggies = value;
            SetProperty(ref doggies, value);
        }
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FormattedAge))]
    [NotifyPropertyChangedFor(nameof(TotalDogDays))]
    private DoggyTableModel selectedDoggy;

    
    public string FormattedAge
    {
        get
            {
            if (selectedDoggy == null) return string.Empty;
                return new AgeCalculator(selectedDoggy.DateOfBirth.ToDateTime()).FormattedAge();
            }
    }

    public string TotalDogDays
    {
        get
        {
            if (selectedDoggy == null) return string.Empty;
            return new AgeCalculator(selectedDoggy.DateOfBirth.ToDateTime()).TotalDogDays.ToString();
        }
    }



}
