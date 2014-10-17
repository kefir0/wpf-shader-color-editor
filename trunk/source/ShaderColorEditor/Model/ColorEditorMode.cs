using System;

namespace Kefir.ShaderColorEditor.Model
{
    internal class ColorEditorMode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorEditorMode" /> class.
        /// </summary>
        /// <param name="name">The display name.</param>
        /// <param name="xyShader">The shader to be used on XY color plane.</param>
        /// <param name="zShader">The shader to be used on color slider.</param>
        /// <param name="updateColor">Update color from coordinates.</param>
        /// <param name="updateCoordinates">Update coordinates from color.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public ColorEditorMode(string name, string xyShader, string zShader, Action updateColor, Action updateCoordinates)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(xyShader) || string.IsNullOrEmpty(zShader) || updateColor == null || updateCoordinates == null)
            {
                throw new ArgumentNullException();
            }

            _name = name;
            _xyShader = xyShader;
            _zShader = zShader;
            _updateColor = updateColor;
            _updateCoordinates = updateCoordinates;
        }

        public string Name
        {
            get { return _name; }
        }

        public string XyShader
        {
            get { return _xyShader; }
        }
        public string ZShader
        {
            get { return _zShader; }
        }

        public void UpdateColor()
        {
            _updateColor();
        }

        public void UpdateCoordinates()
        {
            _updateCoordinates();
        }

        private readonly string _name;
        private readonly Action _updateColor;
        private readonly Action _updateCoordinates;
        private readonly string _xyShader;
        private readonly string _zShader;
    }
}
