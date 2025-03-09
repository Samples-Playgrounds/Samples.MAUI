using System.ComponentModel;
using System.Globalization;

namespace TabbarHandlerIssue.Foundation
{
    [TypeConverter(typeof(ImageSourceStateListConverter))]
    public class ImageSourceStateList
    {
        public FileImageSource Normal { get; private set; }
        public FileImageSource Focused { get; private set; }
        public FileImageSource Disabled { get; private set; }

        public ImageSourceStateList(FileImageSource normal,
                                    FileImageSource focused = null,
                                    FileImageSource disabled = null)
        {
            Normal = normal;
            Focused = focused;
            Disabled = disabled;
        }

        bool Equals(ImageSourceStateList other)
        {
            if (other is null)
            {
                return false;
            }
            return (Normal == other.Normal || Normal.File.Equals(other.Normal.File))
                && (Focused == other.Focused || Focused.File.Equals(other.Focused.File))
                && (Disabled == other.Disabled || Disabled.File.Equals(other.Disabled.File));
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            return obj is ImageSourceStateList
                && Equals((ImageSourceStateList)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Normal.GetHashCode();
                hashCode = (hashCode * 397) ^ Focused.GetHashCode();
                hashCode = (hashCode * 397) ^ Disabled.GetHashCode();
                return hashCode;
            }
        }
    }

    public class ImageSourceStateListConverter : TypeConverter
    {
        public ImageSourceStateListConverter()
        {
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string strValue)
            {
                strValue = strValue.Trim();
                string[] values = strValue.Split(',');

                return new ImageSourceStateList(values[0],
                                                values.Length >= 2 ? values[1] : null,
                                                values.Length >= 3 ? values[2] : null);
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}

