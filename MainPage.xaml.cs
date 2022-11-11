using MyDoggyDetails.Components.Base;
using MyDoggyDetails.Data;
using MyDoggyDetails.Utilities;
using System.Reflection;

namespace MyDoggyDetails;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

		MoveDbToProperPlace();
	}

	private void MoveDbToProperPlace()
	{
		var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
		using (Stream stream = assembly.GetManifestResourceStream("MyDoggyDetails.Database.doggy.db3"))
		{
			using(MemoryStream memoryStream= new MemoryStream())
			{
				stream.CopyTo(memoryStream);
				File.WriteAllBytes(DoggyRepository.dbPath, memoryStream.ToArray());	
			}
		}
	}


}

