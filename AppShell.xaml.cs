using MyDoggyDetails.Data;
using MyDoggyDetails.Models;
using System.Reflection;

namespace MyDoggyDetails;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Pages.DogDetailsPage), typeof(Pages.DogDetailsPage));
        Routing.RegisterRoute(nameof(Pages.BreedDetailPage), typeof(Pages.BreedDetailPage));

        Routing.RegisterRoute(nameof(Pages.MedicalRecordsPage), typeof(Pages.MedicalRecordsPage));
        Routing.RegisterRoute(nameof(Pages.MedicalRecordDetailPage), typeof(Pages.MedicalRecordDetailPage));

        CreateDB();
        //MoveDbToProperPlace();

    }



    /// <summary>
    /// If using the visually built DB (not the scripts)
    /// </summary>
    //private void MoveDbToProperPlace()
    //{

    //    //This does not work - it will always return true?!?.
    //    //So comment this out on first run to install the database
    //    if (File.Exists(DoggyRepository.dbPath))
    //        return;

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

    /// <summary>
    /// Create doggy.db3 from Sql Scripts
    /// </summary>
    private void CreateDB()
    {
        new DoggyRepository().CreateDatabase();

    }

    /// <summary>
    /// Insert test data into doggy.db3
    /// </summary>
    private void InsertMetaDataToDb() 
    { 
    }

}
