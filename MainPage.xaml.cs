namespace MyDoggyDetails;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

		//MoveDbToProperPlace();
	}


	//Moved to AppShell to run on startup
	//private void MoveDbToProperPlace()
	//{
	//	var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
	//	using (Stream stream = assembly.GetManifestResourceStream("MyDoggyDetails.Database.doggy.db3"))
	//	{
	//		using(MemoryStream memoryStream= new MemoryStream())
	//		{
	//			stream.CopyTo(memoryStream);
	//			File.WriteAllBytes(DoggyRepository.dbPath, memoryStream.ToArray());	
	//		}
	//	}
	//}


}

