using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Kefir.ShaderColorEditor.Model;

namespace Kefir.ShaderColorEditor.Shaders
{
    public class RgbEffect : ShaderEffect
    {
        public RgbEffect()
        {
            SetShader(PsFileName);  // default value
        }

        public Brush Input
        {
            get { return ((Brush) (GetValue(InputProperty))); }
            set { SetValue(InputProperty, value); }
        }

        /// <summary>Input color to modify. R=uv.X, G=uv.Y, other components are left intact.</summary>
        public Color InputColor
        {
            get { return ((Color) (GetValue(InputColorProperty))); }
            set { SetValue(InputColorProperty, value); }
        }

        public ColorRgb InputColorRgb
        {
            get { return (ColorRgb)GetValue(InputColorRgbProperty); }
            set { SetValue(InputColorRgbProperty, value); }
        }

        public string PsFileName
        {
            get { return (string)GetValue(PsFileNameProperty); }
            set { SetValue(PsFileNameProperty, value); }
        }

        void InputColorRgb_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateInputColor();
        }

        private void OnInputColorRgbChanged(DependencyPropertyChangedEventArgs e)
        {
            var oldColor = e.OldValue as ColorRgb;
            if (oldColor != null)
            {
                oldColor.PropertyChanged -= InputColorRgb_PropertyChanged;
            }

            var newColor = e.NewValue as ColorRgb;
            if (newColor != null)
            {
                newColor.PropertyChanged += InputColorRgb_PropertyChanged;
            }

            UpdateInputColor();
        }

        private void SetShader(string psFileName)
        {
            var pixelShader = new PixelShader
            {
                UriSource = new Uri(string.Format("/Kefir.ShaderColorEditor;component/Shaders/{0}.ps", psFileName), UriKind.Relative)
            };
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(InputColorProperty);
        }

        private void UpdateInputColor()
        {
            InputColor = InputColorRgb.ToWpfColor();
        }

        public static readonly DependencyProperty InputColorProperty = DependencyProperty.Register("InputColor", typeof(Color), typeof(RgbEffect), new UIPropertyMetadata(Color.FromArgb(255, 0, 0, 0), PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty InputColorRgbProperty =
            DependencyProperty.Register("InputColorRgb", typeof(ColorRgb), typeof(RgbEffect), new PropertyMetadata((d, e) => ((RgbEffect) d).OnInputColorRgbChanged(e)));

        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(RgbEffect), 0);

        public static readonly DependencyProperty PsFileNameProperty =
            DependencyProperty.Register("PsFileName", typeof (string), typeof (RgbEffect),
                new PropertyMetadata("rgb_rg", (d, e) => ((RgbEffect) d).SetShader((string) e.NewValue)));
    }
}
