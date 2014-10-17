using System.Windows.Media;

namespace Kefir.ShaderColorEditor.Model
{
    public static class ColorExtensions
    {
        public static byte DoubleToByteComponent(double colorComponent)
        {
            return (byte) (colorComponent*255);
        }

        public static Color ToWpfColor(this ColorRgb color)
        {
            return new Color
            {
                A = DoubleToByteComponent(color.A),
                R = DoubleToByteComponent(color.R),
                G = DoubleToByteComponent(color.G),
                B = DoubleToByteComponent(color.B)
            };
        }
    }
}
