using Microsoft.Maui.Platform;

public partial class
                                        CustomMapHandler
                                        :
                                        Microsoft.Maui.Maps.Handlers.MapHandler
{
	public static readonly
        IPropertyMapper
            <
                IMap,
                Microsoft.Maui.Maps.Handlers.IMapHandler
            >
                    CustomMapper
                    =
                        new PropertyMapper
                                <
                                    IMap,
                                    Microsoft.Maui.Maps.Handlers.IMapHandler
                                >
                                (Mapper)
                        {
                            [nameof(IMap.Pins)] = MapPins,
                        };

	public CustomMapHandler() : base(CustomMapper, CommandMapper)
	{
	}

	public CustomMapHandler(IPropertyMapper? mapper = null, CommandMapper? commandMapper = null) : base(
		mapper ?? CustomMapper, commandMapper ?? CommandMapper)
	{
	}

	public List<Android.Gms.Maps.Model.Marker> Markers { get; } = new();

	protected override void ConnectHandler(Android.Gms.Maps.MapView platformView)
	{
		base.ConnectHandler(platformView);
		var mapReady = new MapCallbackHandler(this);
		PlatformView.GetMapAsync(mapReady);
	}

	private static new void MapPins(Microsoft.Maui.Maps.Handlers.IMapHandler handler, IMap map)
	{
		if (handler is CustomMapHandler mapHandler)
		{
			foreach (var marker in mapHandler.Markers)
			{
				marker.Remove();
			}

			mapHandler.AddPins(map.Pins);
		}
	}

	private void AddPins(IEnumerable<Microsoft.Maui.Maps.IMapPin> mapPins)
	{
		if (Map is null || MauiContext is null)
		{
			return;
		}

		foreach (var pin in mapPins)
		{
			var pinHandler = pin.ToHandler(MauiContext);
			if (pinHandler is Microsoft.Maui.Maps.Handlers.IMapPinHandler mapPinHandler)
			{
				var markerOption = mapPinHandler.PlatformView;
				if (pin is CustomPin cp)
				{
					cp.ImageSource.LoadImage
                    (
                        MauiContext,
                        result =>
                        {
                            if (result?.Value is Android.Graphics.Drawables.BitmapDrawable bitmapDrawable)
                            {
                                markerOption.SetIcon
                                                (
                                                    Android.Gms.Maps.Model.BitmapDescriptorFactory
                                                                .FromBitmap(bitmapDrawable.Bitmap)
                                                );
                            }

                            AddMarker(Map, pin, Markers, markerOption);
                        }
                    );
				}
				else
				{
					AddMarker(Map, pin, Markers, markerOption);
				}
			}
		}
	}

	private static
        void
                                        AddMarker
                                        (
                                            Android.Gms.Maps.GoogleMap map,
                                            IMapPin pin,
                                            ICollection<Marker> markers,
                                            MarkerOptions markerOption
                                        )
	{
		var marker = map.AddMarker(markerOption);
		pin.MarkerId = marker.Id;
		markers.Add(marker);
	}
}
