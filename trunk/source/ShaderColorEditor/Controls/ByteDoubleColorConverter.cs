using System;
using System.Globalization;
using System.Windows.Data;
using Kefir.ShaderColorEditor.Model;

namespace Kefir.ShaderColorEditor.Controls
{
    internal class ByteDoubleColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value);
        }

        private static object Convert(object value)
        {
            if (value is double)
            {
                return ColorExtensions.DoubleToByteComponent((double) value);
            }
            if (value is byte)
            {
                return ColorExtensions.ByteToDoubleComponent((byte) value);
            }
            var s = value as string;
            if (s != null)
            {
                byte b;
                if (byte.TryParse(s, out b))
                {
                    return ColorExtensions.ByteToDoubleComponent(b);
                }
            }

            return value;
        }
    }
}
