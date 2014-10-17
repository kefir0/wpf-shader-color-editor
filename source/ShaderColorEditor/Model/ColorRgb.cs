using System;

namespace Kefir.ShaderColorEditor.Model
{
    public class ColorRgb : ModelBase
    {
        public double A
        {
            get { return _a; }
            set
            {
                ValidateComponent(value);
                _a = value;
                OnPropertyChanged();
            }
        }

        public double B
        {
            get { return _b; }
            set
            {
                ValidateComponent(value);
                _b = value;
                OnPropertyChanged();
            }
        }

        public double G
        {
            get { return _g; }
            set
            {
                ValidateComponent(value);
                _g = value;
                OnPropertyChanged();
            }
        }

        public double R
        {
            get { return _r; }
            set
            {
                ValidateComponent(value);
                _r = value;
                OnPropertyChanged();
            }
        }

        private static void ValidateComponent(double component)
        {
            if (component < 0)
            {
                throw new ArgumentOutOfRangeException("Color component can't be less than 0");
            }
            if (component > 1)
            {
                throw new ArgumentOutOfRangeException("Color component can't be greater than 1");
            }
        }

        private double _a;
        private double _b;
        private double _g;
        private double _r;
    }
}
