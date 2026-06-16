using MyDoggyDetails.Repository;
using System.Diagnostics;

namespace MyDoggyDetails;

public partial class App : Application
{
    private readonly DatabaseInitializer _initializer;
    private readonly AppShell _appShell;

    public App(DatabaseInitializer initializer, AppShell appShell)
	{
        _initializer = initializer;
        _appShell = appShell;
		InitializeComponent();
		_ = InitializeAsync();
    }

    protected override Window CreateWindow(IActivationState? activationState)
        => new Window(_appShell);

    private async Task InitializeAsync()
    {
        try
        {
            await _initializer.InitializeAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Database initialisation failed: {ex}");
        }
    }
}
