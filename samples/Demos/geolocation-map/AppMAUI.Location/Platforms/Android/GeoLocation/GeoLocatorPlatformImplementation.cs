namespace HolisticWare.MAUI.GeoLocation;

public partial class
                                        GeoLocatorPlatformImplementation
                                        :
                                        HolisticWare.MAUI.GeoLocation.IGeoLocator
{
	GeolocationContinuousListener? locator;

	public async
        Task
                                        StartListening
                                        (
                                            IProgress<Microsoft.Maui.Devices.Sensors.Location> position_changed_progeress,
                                            CancellationToken cancellation_token
                                        )
	{
        PermissionStatus permission = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();

		if (permission != PermissionStatus.Granted)
		{
			permission = await Permissions.RequestAsync<Permissions.LocationAlways>();
			if (permission != PermissionStatus.Granted)
			{
				await CommunityToolkit.Maui.Alerts.Toast
                                                    .Make("No permission")
                                                    .Show(CancellationToken.None)
                                                    ;
				return;
			}
		}

		locator = new GeolocationContinuousListener();
		var taskCompletionSource = new TaskCompletionSource();
		cancellation_token.Register
                                (
                                    () =>
                                        {
                                            locator.Dispose();
                                            locator = null;
                                            taskCompletionSource.TrySetResult();
                                        }
                                );

		locator.OnLocationChangedAction =
                        location =>
			                    position_changed_progeress
                                        .Report
                                            (
                                                new Microsoft.Maui.Devices.Sensors.Location
                                                                                    (
                                                                                        location.Latitude,
                                                                                        location.Longitude
                                                                                    )
                                            );
		await taskCompletionSource.Task;
	}
}

internal class
                                        GeolocationContinuousListener
                                        :
                                        Java.Lang.Object,
                                        Android.Locations.ILocationListener
{
	public
        Action<Android.Locations.Location>?
                                        OnLocationChangedAction
        {
            get;
            set;
        }

	Android.Locations.LocationManager?
                                        location_manager;

	public
                                        GeolocationContinuousListener
                                        (
                                        )
	{
		location_manager = (Android.Locations.LocationManager?)
                                    Android.App.Application
                                                    .Context
                                                        .GetSystemService
                                                                (
                                                                    Android.Content.Context.LocationService
                                                                );

		location_manager?.RequestLocationUpdates
                                        (
                                            // Android.Locations.LocationManager.GpsProvider,
                                            // Android.Locations.LocationManager.NetworkProvider
                                            // Android.Locations.LocationManager.PassiveProvider
                                            // Android.Locations.LocationManager.FusedProvider
                                            Android.Locations.LocationManager.GpsProvider,
                                            minTimeMs: 1000,
                                            minDistanceM: 0,
                                            this
                                        );

        return;
	}

	public
        void
                                        OnLocationChanged
                                        (
                                            Android.Locations.Location location
                                        )
	{
		OnLocationChangedAction?.Invoke(location);

        return;
	}

	public
        void
                                        OnProviderDisabled
                                        (
                                            string provider
                                        )
	{
        return;
	}

	public
        void
                                        OnProviderEnabled
                                        (
                                            string provider
                                        )
	{
        return;
	}

	public
        void
                                        OnStatusChanged
                                        (
                                            string? provider,
                                            [Android.Runtime.GeneratedEnum]
                                                Android.Locations.Availability status,
                                            Android.OS.Bundle? extras
                                        )
	{
        return;
	}

	protected override
        void
                                        Dispose
                                        (
                                            bool disposing
                                        )
	{
		base.Dispose(disposing);
		location_manager?.RemoveUpdates(this);
		location_manager?.Dispose();

        return;
	}
}
