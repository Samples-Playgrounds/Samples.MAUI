using System.ComponentModel;

namespace TabbarHandlerIssue.CoreUI
{
    [TypeConverter(typeof(ResizeModeTypeConverter))]
    public enum ResizeMode
    {
        Stretch,
        Tile
    }

    public class ResizeModeTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, System.Globalization.CultureInfo? culture, object value)
        {
            if (value is string strValue)
            {
                if (Enum.TryParse(strValue, true, out ResizeMode resizeMode))
                {
                    return resizeMode;
                }
                else
                {
                    throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(ResizeMode)}");
                }
            }
            else
            {
                return base.ConvertFrom(context, culture, value);
            }
        }
    }
}
