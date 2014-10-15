using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Kefir.ShaderColorEditor.Controls
{
    public class ColorPickerRect : Control
    {
        static ColorPickerRect()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPickerRect), new FrameworkPropertyMetadata(typeof(ColorPickerRect)));
        }

        public double PickX
        {
            get { return (double)GetValue(PickXProperty); }
            set { SetValue(PickXProperty, value); }
        }

        public double PickY
        {
            get { return (double)GetValue(PickYProperty); }
            set { SetValue(PickYProperty, value); }
        }

        protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        {
            // Receive all hits (non-transparent behavior)
            return new PointHitTestResult(this, hitTestParameters.HitPoint);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            // TODO: Proper drag mechanism
            var pos = e.GetPosition(this);
            PickX = pos.X;
            PickY = pos.Y;
            base.OnMouseDown(e);
        }

        public static readonly DependencyProperty PickXProperty =
            DependencyProperty.Register("PickX", typeof(double), typeof(ColorPickerRect));

        public static readonly DependencyProperty PickYProperty =
            DependencyProperty.Register("PickY", typeof(double), typeof(ColorPickerRect));
    }
}
