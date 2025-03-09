using System.ComponentModel;

namespace TabbarHandlerIssue.CoreUI
{
    /// <summary>
    /// Edge insets class definition specific for iOS only.
    /// </summary>
    [TypeConverter(typeof(EdgeInsetsTypeConverter))]
    public struct EdgeInsets
    {
        public float Top { get; set; }
        public float Left { get; set; }
        public float Bottom { get; set; }
        public float Right { get; set; }

        public EdgeInsets(float top, float left, float bottom, float right) : this()
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }

        bool Equals(EdgeInsets other)
        {
            return Top.Equals(other.Top)
                && Left.Equals(other.Left)
                && Bottom.Equals(other.Bottom)
                && Right.Equals(other.Right);
        }

        public override bool Equals(object obj)
        {
            return obj is EdgeInsets && Equals((EdgeInsets)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Left.GetHashCode();
                hashCode = (hashCode * 397) ^ Top.GetHashCode();
                hashCode = (hashCode * 397) ^ Right.GetHashCode();
                hashCode = (hashCode * 397) ^ Bottom.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(EdgeInsets left, EdgeInsets right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EdgeInsets left, EdgeInsets right)
        {
            return !left.Equals(right);
        }

        public void Deconstruct(out double top, out double left, out double bottom, out double right)
        {
            top = Top;
            left = Left;
            bottom = Bottom;
            right = Right;
        }
    }

    public class EdgeInsetsTypeConverter : TypeConverter
    {
        public EdgeInsetsTypeConverter()
        {
        }

        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, System.Globalization.CultureInfo? culture, object value)
        {
            if (value is string str)
            {
                string[] parts = str.Split(',');
                if (parts.Length == 4 && float.TryParse(parts[0], out float top) &&
                    float.TryParse(parts[1], out float left) && float.TryParse(parts[2], out float bottom) &&
                    float.TryParse(parts[3], out float right))
                {
                    return new EdgeInsets(top, left, bottom, right);
                }
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
