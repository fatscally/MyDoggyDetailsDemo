namespace MyDoggyDetails;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        RegisterRoutes();
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(Pages.DogDetailsPage), typeof(Pages.DogDetailsPage));
        Routing.RegisterRoute(nameof(Pages.BreedDetailPage), typeof(Pages.BreedDetailPage));
        Routing.RegisterRoute(nameof(Pages.MedicalRecordsPage), typeof(Pages.MedicalRecordsPage));
        Routing.RegisterRoute(nameof(Pages.MedicalRecordDetailPage), typeof(Pages.MedicalRecordDetailPage));
    }




}
