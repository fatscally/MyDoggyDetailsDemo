using MyDoggyDetails.Repository;

namespace MyDoggyDetails;

public partial class App : Application
{
	public App(DatabaseInitializer initializer)
	{
		InitializeComponent();

		MainPage = new AppShell(initializer);
	}
}
