using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Kefir.ShaderColorEditor.Shaders
{
    public class RgbEffect : ShaderEffect
    {
        #region public static fields

        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(RgbEffect), 0);
        public static readonly DependencyProperty InputColorProperty = DependencyProperty.Register("InputColor", typeof(Color), typeof(RgbEffect), new UIPropertyMetadata(Color.FromArgb(255, 0, 0, 0), PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty PsFileNameProperty =
            DependencyProperty.Register("PsFileName", typeof (string), typeof (RgbEffect),
                new PropertyMetadata("rgb_rg", (d, e) => ((RgbEffect) d).SetShader((string) e.NewValue)));

        #endregion

        #region public constructors

        public RgbEffect()
        {
            SetShader(PsFileName);  // default value
        }

        #endregion

        #region public properties and indexers

        public string PsFileName
        {
            get { return (string)GetValue(PsFileNameProperty); }
            set { SetValue(PsFileNameProperty, value); }
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

        #endregion

        #region private methods

        private void SetShader(string psFileName)
        {
            var pixelShader = new PixelShader
            {
                UriSource = new Uri(string.Format("/ShaderColorEditor;component/Shaders/{0}.ps", psFileName), UriKind.Relative)
            };
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(InputColorProperty);
        }

        #endregion
    }
}
