using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Kefir.ShaderColorEditor.Model;

namespace Kefir.ShaderColorEditor.Controls
{
    internal class ColorPickerRect : Control
    {
        static ColorPickerRect()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPickerRect), new FrameworkPropertyMetadata(typeof(ColorPickerRect)));
        }

        public ColorRgb InputColor
        {
            get { return (ColorRgb)GetValue(InputColorProperty); }
            set { SetValue(InputColorProperty, value); }
        }

        public double NormPickX
        {
            get { return (double)GetValue(NormPickXProperty); }
            set { SetValue(NormPickXProperty, value); }
        }

        public double NormPickY
        {
            get { return (double)GetValue(NormPickYProperty); }
            set { SetValue(NormPickYProperty, value); }
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

        public string PsFileName
        {
            get { return (string)GetValue(PsFileNameProperty); }
            set { SetValue(PsFileNameProperty, value); }
        }

        protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        {
            // Receive all hits (non-transparent behavior)
            return new PointHitTestResult(this, hitTestParameters.HitPoint);
        }

        /// <summary>
        /// Invoked when an unhandled <see cref="E:System.Windows.UIElement.PreviewMouseLeftButtonDown" /> routed event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseButtonEventArgs" /> that contains the event data. The event data reports that the left mouse button was pressed.</param>
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
            CaptureMouse();
        }

        /// <summary>
        /// Invoked when an unhandled <see cref="E:System.Windows.UIElement.PreviewMouseLeftButtonUp" /> routed event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseButtonEventArgs" /> that contains the event data. The event data reports that the left mouse button was released.</param>
        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonUp(e);
            ReleaseMouseCapture();
        }

        /// <summary>
        /// Invoked when an unhandled <see cref="E:System.Windows.UIElement.PreviewMouseMove" /> attached event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);

            if (e.LeftButton == MouseButtonState.Pressed && IsMouseCaptured)
            {
                var pos = e.GetPosition(this);
                PickX = pos.X;
                PickY = pos.Y;
            }
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            // Update picker position according to new size
            OnNormPickXChanged();
            OnNormPickYChanged();
        }

        private void OnNormPickXChanged()
        {
            Update(() => PickX = NormPickX*ActualWidth);
        }

        private void OnNormPickYChanged()
        {
            Update(() => PickY = NormPickY*ActualHeight);
        }

        private void OnPickXChanged()
        {
            Update(() => NormPickX = PickX / ActualWidth);
        }

        private void OnPickYChanged()
        {
            Update(() => NormPickY = PickY / ActualHeight);
        }

        private void Update(Action action)
        {
            if (_isUpdating)
            {
                return;
            }

            _isUpdating = true;
            try
            {
                action();
            }
            finally
            {
                _isUpdating = false;
            }
        }

        public static readonly DependencyProperty InputColorProperty =
            DependencyProperty.Register("InputColor", typeof(ColorRgb), typeof(ColorPickerRect));

        public static readonly DependencyProperty NormPickXProperty =
            DependencyProperty.Register("NormPickX", typeof(double), typeof(ColorPickerRect), new PropertyMetadata((d, e) => ((ColorPickerRect)d).OnNormPickXChanged()));

        public static readonly DependencyProperty NormPickYProperty =
            DependencyProperty.Register("NormPickY", typeof(double), typeof(ColorPickerRect), new PropertyMetadata((d, e) => ((ColorPickerRect) d).OnNormPickYChanged()));

        public static readonly DependencyProperty PickXProperty =
            DependencyProperty.Register("PickX", typeof(double), typeof(ColorPickerRect), new PropertyMetadata((d, e) => ((ColorPickerRect)d).OnPickXChanged()));

        public static readonly DependencyProperty PickYProperty =
            DependencyProperty.Register("PickY", typeof(double), typeof(ColorPickerRect), new PropertyMetadata((d, e) => ((ColorPickerRect)d).OnPickYChanged()));

        public static readonly DependencyProperty PsFileNameProperty =
            DependencyProperty.Register("PsFileName", typeof(string), typeof(ColorPickerRect), new PropertyMetadata("rgb_rg"));


        private bool _isUpdating;
    }
}
