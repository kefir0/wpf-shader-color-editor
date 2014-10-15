namespace Kefir.ShaderColorEditor.Model
{
    public class ColorRgb : ModelBase
    {
        public double A
        {
            get { return _a; }
            set { _a = value; }
        }

        public double B
        {
            get { return _b; }
            set { _b = value; }
        }

        public double G
        {
            get { return _g; }
            set { _g = value; }
        }

        public double R
        {
            get { return _r; }
            set { _r = value; }
        }

        private double _a;
        private double _b;
        private double _g;
        private double _r;
    }
}
