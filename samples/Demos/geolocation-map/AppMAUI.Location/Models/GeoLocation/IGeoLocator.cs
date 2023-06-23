namespace HolisticWare.MAUI.GeoLocation;

public
    interface
                                        IGeoLocator
{
    Task
                                        StartListening
                                        (
                                            IProgress<Microsoft.Maui.Devices.Sensors.Location> position_changed_progeress,
                                            CancellationToken cancellation_token
                                        );
}

