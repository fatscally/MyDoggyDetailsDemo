using MyDoggyDetails.Data;
using System.Reflection;

namespace MyDoggyDetails;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Pages.DogDetailsPage), typeof(Pages.DogDetailsPage));


        MoveDbToProperPlace();


    }

    private void MoveDbToProperPlace()
    {


        if (File.Exists(DoggyRepository.dbPath)) return;

        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
        using (Stream stream = assembly.GetManifestResourceStream("MyDoggyDetails.Database.doggy.db3"))
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                File.WriteAllBytes(DoggyRepository.dbPath, memoryStream.ToArray());
            }
        }

    }


}
