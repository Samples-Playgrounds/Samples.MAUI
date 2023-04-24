namespace AppMAUI.Issue14729.PermissionsExternalStorage;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        CheckForPermissions();

		SemanticScreenReader.Announce(CounterBtn.Text);

        return;
	}

    public async Task CheckForPermissions()
    {
        var status_write = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
        var status_read = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

        if (Permissions.ShouldShowRationale<Permissions.StorageWrite>())
        {
            // just testing
        }

        if (Permissions.ShouldShowRationale<Permissions.StorageRead>())
        {
            // just testing
        }

        status_write = await Permissions.RequestAsync<Permissions.StorageWrite>();
        status_read = await Permissions.RequestAsync<Permissions.StorageRead>();

        if (status_write != PermissionStatus.Granted)
        {
            // still not granted
        }

        // forward user to settings so they can grant permission
        AppInfo.Current.ShowSettingsUI();
    }
}

