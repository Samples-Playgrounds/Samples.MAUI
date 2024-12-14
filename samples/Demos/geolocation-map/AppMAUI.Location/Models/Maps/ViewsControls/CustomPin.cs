namespace HolisticWare.MAUI.Maps;

using Microsoft.Maui.Controls.Maps;

public partial class
                                        CustomPin
                                        :
                                        Pin
{
	public static readonly
        BindableProperty
                                        ImageSourceProperty
            = BindableProperty.Create
                                    (
                                        nameof(ImageSource),
                                        typeof(ImageSource),
                                        typeof(CustomPin)
                                    );

	public
        ImageSource?
                                        ImageSource
	{
		get => (ImageSource?)GetValue(ImageSourceProperty);
		set => SetValue(ImageSourceProperty, value);
	}
}
